using Seguros.Application.DTOs.Apolice;
using Seguros.Application.DTOs.Cliente;
using Seguros.Application.DTOs.Pagamento;
using Seguros.Application.DTOs.Seguradora;
using Seguros.Application.DTOs.Sinistro;
using Seguros.Application.Exceptions;
using Seguros.Application.Interfaces;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seguros.Application.Services
{
    public class ApoliceService : IApoliceService
    {
        private readonly IApoliceRepository _apoliceRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ISeguradoraRepository _seguradoraRepository;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly ISinistroRepository _sinistroRepository;

        public ApoliceService(
            IApoliceRepository apoliceRepository,
            IClienteRepository clienteRepository,
            ISeguradoraRepository seguradoraRepository,
            IPagamentoRepository pagamentoRepository,
            ISinistroRepository sinistroRepository)
        {
            _apoliceRepository = apoliceRepository;
            _clienteRepository = clienteRepository;
            _seguradoraRepository = seguradoraRepository;
            _pagamentoRepository = pagamentoRepository;
            _sinistroRepository = sinistroRepository;
        }
        public async Task<ApoliceGetDTO> AddAsync(ApolicePostDTO apolicePostDTO)
        {
            Apolice apolice = new Apolice
            {                
                ClienteID = apolicePostDTO.ClienteID,
                VigenciaInicio = apolicePostDTO.VigenciaInicio,
                VigenciaFim = apolicePostDTO.VigenciaFim,
                SeguradoraID = apolicePostDTO.SeguradoraID,
                TipoSeguro = apolicePostDTO.TipoSeguro,
                Produto = apolicePostDTO.Produto,
                PagamentoID = apolicePostDTO.PagamentoID,
                PremioLiquido = apolicePostDTO.PremioLiquido,
                Comissao = apolicePostDTO.Comissao,
                linkApolice = apolicePostDTO.linkApolice

            };
            var result = await _apoliceRepository.AddAsync(apolice);
            return new ApoliceGetDTO
            {                
                Id = result.Id,
                ClienteID = result.ClienteID,
                VigenciaInicio = result.VigenciaInicio,
                VigenciaFim = result.VigenciaFim,
                SeguradoraID = result.SeguradoraID,
                TipoSeguro = result.TipoSeguro,
                Produto = result.Produto,
                PagamentoID = result.PagamentoID,
                PremioLiquido = result.PremioLiquido,
                Comissao = result.Comissao,
                linkApolice = result.linkApolice
            };
        }

        public async Task<ApoliceGetDTO> DeleteAsync(int id)
        {
            var apolice = await _apoliceRepository.GetByIdAsync(id);
            if (apolice == null)
                throw new NotFoundException("Apolice não encontrada.");
            apolice.Excluido = true;
            var updatedApolice = await _apoliceRepository.UpdateAsync(apolice);
            return new ApoliceGetDTO
            {                
                Id = updatedApolice.Id,
                ClienteID = updatedApolice.ClienteID,
                VigenciaInicio = updatedApolice.VigenciaInicio,
                VigenciaFim = updatedApolice.VigenciaFim,
                SeguradoraID = updatedApolice.SeguradoraID,
                TipoSeguro = updatedApolice.TipoSeguro,
                Produto = updatedApolice.Produto,
                PagamentoID = updatedApolice.PagamentoID,
                PremioLiquido = updatedApolice.PremioLiquido,
                Comissao = updatedApolice.Comissao,
                linkApolice = updatedApolice.linkApolice
            };

        }

        public async Task<List<ApoliceGetDTO>> GetAllAsync()
        {
            var apolices = await _apoliceRepository.GetAllAsync();
            return apolices.Select(a => new ApoliceGetDTO
            {
                Id = a.Id,
                ClienteID = a.ClienteID,
                VigenciaInicio = a.VigenciaInicio,
                VigenciaFim = a.VigenciaFim,
                SeguradoraID = a.SeguradoraID,
                TipoSeguro = a.TipoSeguro,
                Produto = a.Produto,
                PagamentoID = a.PagamentoID,
                PremioLiquido = a.PremioLiquido,
                Comissao = a.Comissao,
                linkApolice = a.linkApolice
            }).ToList();
        }

        public async Task<List<ApoliceDetailsGetDTO>> GetAllDetailsAsync()
        {
            var apolices = await _apoliceRepository.GetAllAsync();
            var clientes = await _clienteRepository.GetAllAsync();
            var seguradoras = await _seguradoraRepository.GetAllAsync();
            var pagamentos = await _pagamentoRepository.GetAllAsync();
            var sinistros = await _sinistroRepository.GetAllAsync();
            var dtos = new List<ApoliceDetailsGetDTO>();

            foreach (var a in apolices)
            {
                dtos.Add(MapToDetails(
                    a,
                    clientes.FirstOrDefault(c => c.Id == a.ClienteID),
                    seguradoras.FirstOrDefault(s => s.Id == a.SeguradoraID),
                    pagamentos.FirstOrDefault(p => p.Id == a.PagamentoID),
                    sinistros.Where(s => s.SeguroID == a.Id)));
            }

            return dtos;
        }

        public async Task<ApoliceGetDTO> GetByIdAsync(int id)
        {
            var apolice = await _apoliceRepository.GetByIdAsync(id);
            if (apolice == null)
                throw new NotFoundException("Apolice não encontrada.");
            return new ApoliceGetDTO
            {
                Id = apolice.Id,
                ClienteID = apolice.ClienteID,
                VigenciaInicio = apolice.VigenciaInicio,
                VigenciaFim = apolice.VigenciaFim,
                SeguradoraID = apolice.SeguradoraID,
                TipoSeguro = apolice.TipoSeguro,
                Produto = apolice.Produto,
                PagamentoID = apolice.PagamentoID,
                PremioLiquido = apolice.PremioLiquido,
                Comissao = apolice.Comissao,
                linkApolice = apolice.linkApolice
            };                
        }

        public async Task<ApoliceDetailsGetDTO> GetDetailsByIdAsync(int id)
        {
            var apolice = await _apoliceRepository.GetByIdAsync(id);
            if (apolice == null)
                return null;

            var cliente = await _clienteRepository.GetByIdAsync(apolice.ClienteID);
            var seguradora = await _seguradoraRepository.GetByIdAsync(apolice.SeguradoraID);
            var pagamento = await _pagamentoRepository.GetByIdAsync(apolice.PagamentoID);
            var sinistros = await _sinistroRepository.GetAllAsync();

            return MapToDetails(
                apolice,
                cliente,
                seguradora,
                pagamento,
                sinistros.Where(s => s.SeguroID == apolice.Id));
        }

        public async Task<ApoliceGetDTO> UpdateAsync(ApolicePutDTO apolicePutDTO)
        {
            var apolice = await _apoliceRepository.GetByIdAsync(apolicePutDTO.Id);
            if (apolice == null)
                throw new NotFoundException("Apolice não encontrada.");
            var apoliceUpdated = await _apoliceRepository.UpdateAsync(apolice);

            return new ApoliceGetDTO
            {
                Id = apoliceUpdated.Id,
                ClienteID = apoliceUpdated.ClienteID,
                VigenciaInicio = apoliceUpdated.VigenciaInicio,
                VigenciaFim = apoliceUpdated.VigenciaFim,
                SeguradoraID = apoliceUpdated.SeguradoraID,
                TipoSeguro = apoliceUpdated.TipoSeguro,    
                Produto = apoliceUpdated.Produto,
                PagamentoID = apoliceUpdated.PagamentoID,
                PremioLiquido = apoliceUpdated.PremioLiquido,
                Comissao = apoliceUpdated.Comissao,
                linkApolice = apoliceUpdated.linkApolice
            };
        }

        private static ApoliceDetailsGetDTO MapToDetails(
            Apolice apolice,
            Cliente cliente,
            Seguradora seguradora,
            Pagamento pagamento,
            IEnumerable<Sinistro> sinistros)
        {
            var sinistrosDto = new List<SinistroGetDTO>();
            foreach (var s in sinistros)
            {
                sinistrosDto.Add(new SinistroGetDTO
                {
                    ID = s.ID,
                    SeguroID = s.SeguroID,
                    DataOcorrencia = s.DataOcorrencia,
                    NumeroSinistro = s.NumeroSinistro
                });
            }

            return new ApoliceDetailsGetDTO
            {
                Id = apolice.Id,
                Cliente = cliente == null ? null : new ClienteGetDTO
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    CPF = cliente.CPF,
                    CNPJ = cliente.CNPJ
                },
                VigenciaInicio = apolice.VigenciaInicio,
                VigenciaFim = apolice.VigenciaFim,
                Seguradora = seguradora == null ? null : new SeguradoraGetDTO
                {
                    Id = seguradora.Id,
                    Nome = seguradora.Nome
                },
                TipoSeguro = apolice.TipoSeguro,                
                Produto = apolice.Produto,
                Pagamento = pagamento == null ? null : new PagamentoGetDTO
                {
                    Id = pagamento.Id,
                    TipoPagamento = pagamento.TipoPagamento,
                    ValorTotal = pagamento.ValorTotal,
                    QuantidadeParcelas = pagamento.QuantidadeParcelas
                },
                PremioLiquido = apolice.PremioLiquido,
                Comissao = apolice.Comissao,
                Sinistros = sinistrosDto
            };
        }
    }
}
