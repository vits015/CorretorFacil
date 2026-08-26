using Seguros.Application.DTOs.Pagamento;
using Seguros.Application.Interfaces;
using Seguros.Application.Exceptions;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seguros.Application.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IParcelaRepository _parcelaRepository;

        public PagamentoService(IPagamentoRepository pagamentoRepository, IParcelaRepository parcelaRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            _parcelaRepository = parcelaRepository;
        }

        public async Task<PagamentoGetDTO> AddAsync(PagamentoPostDTO pagamentoPostDTO)
        {
            var pagamento = new Pagamento
            {
                TipoPagamento = pagamentoPostDTO.TipoPagamento,
                ValorTotal = pagamentoPostDTO.ValorTotal,
                QuantidadeParcelas = pagamentoPostDTO.QuantidadeParcelas
            };

            var created = await _pagamentoRepository.AddAsync(pagamento);
            for (var i = 0; i < created.QuantidadeParcelas; i++)
            {
                await _parcelaRepository.AddAsync(new Parcela
                {
                    PagamentoID = created.Id,
                    Valor = created.ValorTotal / created.QuantidadeParcelas
                });
            }

            return new PagamentoGetDTO
            {
                Id = created.Id,
                TipoPagamento = created.TipoPagamento,
                ValorTotal = created.ValorTotal,
                QuantidadeParcelas = created.QuantidadeParcelas
            };
        }

        public async Task<PagamentoGetDTO> DeleteAsync(int id)
        {
            var deleted = await _pagamentoRepository.DeleteAsync(id);
            if (deleted == null)
                return null;

            return new PagamentoGetDTO
            {
                Id = deleted.Id,
                TipoPagamento = deleted.TipoPagamento,
                ValorTotal = deleted.ValorTotal,
                QuantidadeParcelas = deleted.QuantidadeParcelas
            };
        }

        public async Task<List<PagamentoGetDTO>> GetAllAsync()
        {
            var pagamentos = await _pagamentoRepository.GetAllAsync();
            var dtos = new List<PagamentoGetDTO>();

            foreach (var p in pagamentos)
            {
                dtos.Add(new PagamentoGetDTO
                {
                    Id = p.Id,
                    TipoPagamento = p.TipoPagamento,
                    ValorTotal = p.ValorTotal,
                    QuantidadeParcelas = p.QuantidadeParcelas
                });
            }

            return dtos;
        }

        public async Task<PagamentoGetDTO> GetByIdAsync(int id)
        {
            var pagamento = await _pagamentoRepository.GetByIdAsync(id);
            if (pagamento == null)
                return null;

            return new PagamentoGetDTO
            {
                Id = pagamento.Id,
                TipoPagamento = pagamento.TipoPagamento,
                ValorTotal = pagamento.ValorTotal,
                QuantidadeParcelas = pagamento.QuantidadeParcelas
            };
        }

        public async Task<PagamentoGetDTO> UpdateAsync(PagamentoPutDTO pagamentoPutDTO)
        {
            var pagamento = new Pagamento
            {
                Id = pagamentoPutDTO.Id,
                TipoPagamento = pagamentoPutDTO.TipoPagamento,
                ValorTotal = pagamentoPutDTO.ValorTotal,
                QuantidadeParcelas = pagamentoPutDTO.QuantidadeParcelas
            };            

            var pagamentoOld = await _pagamentoRepository.GetByIdAsync(pagamento.Id);
            if (pagamentoOld == null)
                return null;
            pagamentoOld.Parcelas = pagamento.Parcelas;
            pagamentoOld.QuantidadeParcelas = pagamento.QuantidadeParcelas;
            pagamentoOld.TipoPagamento = pagamento.TipoPagamento;
            pagamentoOld.ValorTotal = pagamento.ValorTotal;
            var updated = await _pagamentoRepository.UpdateAsync(pagamentoOld);            
            if (updated.QuantidadeParcelas != pagamentoOld.QuantidadeParcelas)
            {
                var parcelas = await _parcelaRepository.GetAllAsync();
                parcelas.Where(p => p.PagamentoID == pagamento.Id);
                foreach (var p in parcelas)
                {
                    await _parcelaRepository.DeleteAsync(p.Id);
                }
                for (var i = 0; i < pagamento.QuantidadeParcelas; i++)
                {
                    await _parcelaRepository.AddAsync(new Parcela { PagamentoID = pagamento.Id, Valor = pagamento.ValorTotal / pagamento.QuantidadeParcelas });
                }
            } else 
            {
                var parcelas = await _parcelaRepository.GetAllAsync();
                parcelas.Where(p => p.PagamentoID == pagamento.Id);
                foreach (var p in parcelas)
                {
                    await _parcelaRepository.UpdateAsync(p);
                }
            }


            return new PagamentoGetDTO
            {
                Id = updated.Id,
                TipoPagamento = updated.TipoPagamento,
                ValorTotal = updated.ValorTotal,
                QuantidadeParcelas = updated.QuantidadeParcelas
            };
                        
        }
    }
}
