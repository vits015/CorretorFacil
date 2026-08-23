using Seguros.Application.DTOs.Parcela;
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
    public class ParcelaService : IParcelaService
    {
        private readonly IParcelaRepository _parcelaRepository;
        private readonly IPagamentoRepository _pagamentoRepository;

        public ParcelaService(IParcelaRepository parcelaRepository, IPagamentoRepository pagamentoRepository)
        {
            _parcelaRepository = parcelaRepository;
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<ParcelaGetDTO> AddAsync(ParcelaPostDTO parcelaPostDTO)
        {
            var pagamento = await _pagamentoRepository.GetByIdAsync(parcelaPostDTO.PagamentoID);
            if (pagamento == null)
                throw new NotFoundException("Pagamento não encontrado");

            var parcela = new Parcela
            {
                Valor = parcelaPostDTO.Valor,
                DataVencimento = parcelaPostDTO.DataVencimento,
                PagamentoID = parcelaPostDTO.PagamentoID
            };

            var created = await _parcelaRepository.AddAsync(parcela);
            return new ParcelaGetDTO
            {
                Id = created.Id,
                Valor = created.Valor,
                DataVencimento = created.DataVencimento,
                PagamentoID = created.PagamentoID
            };
        }

        public async Task<ParcelaGetDTO> DeleteAsync(int id)
        {
            var deleted = await _parcelaRepository.DeleteAsync(id);
            if (deleted == null)
                return null;

            return new ParcelaGetDTO
            {
                Id = deleted.Id,
                Valor = deleted.Valor,
                DataVencimento = deleted.DataVencimento,
                PagamentoID = deleted.PagamentoID
            };
        }

        public async Task<List<ParcelaGetDTO>> GetAllAsync()
        {
            var parcelas = await _parcelaRepository.GetAllAsync();
            var dtos = new List<ParcelaGetDTO>();

            foreach (var p in parcelas)
            {
                dtos.Add(new ParcelaGetDTO
                {
                    Id = p.Id,
                    Valor = p.Valor,
                    DataVencimento = p.DataVencimento,
                    PagamentoID = p.PagamentoID
                });
            }

            return dtos;
        }

        public async Task<ParcelaGetDTO> GetByIdAsync(int id)
        {
            var parcela = await _parcelaRepository.GetByIdAsync(id);
            if (parcela == null)
                return null;

            return new ParcelaGetDTO
            {
                Id = parcela.Id,
                Valor = parcela.Valor,
                DataVencimento = parcela.DataVencimento,
                PagamentoID = parcela.PagamentoID
            };
        }

        public async Task<ParcelaGetDTO> UpdateAsync(ParcelaPutDTO parcelaPutDTO)
        {
            var parcela = new Parcela
            {
                Id = parcelaPutDTO.Id,
                Valor = parcelaPutDTO.Valor,
                DataVencimento = parcelaPutDTO.DataVencimento
            };

            var updated = await _parcelaRepository.UpdateAsync(parcela);
            if (updated == null)
                return null;

            return new ParcelaGetDTO
            {
                Id = updated.Id,
                Valor = updated.Valor,
                DataVencimento = updated.DataVencimento,
                PagamentoID = updated.PagamentoID
            };
        }
    }
}
