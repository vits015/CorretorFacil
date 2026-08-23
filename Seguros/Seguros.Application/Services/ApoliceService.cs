using Microsoft.AspNetCore.Http.HttpResults;
using Seguros.Application.DTOs.Apolice;
using Seguros.Application.Exceptions;
using Seguros.Application.Interfaces;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using Seguros.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.Services
{
    public class ApoliceService : IApoliceService
    {
        private readonly IApoliceRepository _apoliceRepository;

        public ApoliceService(IApoliceRepository apoliceRepository)
        {
            _apoliceRepository = apoliceRepository;
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
                Situacao = apolicePostDTO.Situacao,
                PagamentoID = apolicePostDTO.PagamentoID,
                PremioLiquido = apolicePostDTO.PremioLiquido,
                Comissao = apolicePostDTO.Comissao
            };
            var result = await _apoliceRepository.AddAsync(apolice);
            return new ApoliceGetDTO
            {                
                ClienteID = result.ClienteID,
                VigenciaInicio = result.VigenciaInicio,
                VigenciaFim = result.VigenciaFim,
                SeguradoraID = result.SeguradoraID,
                TipoSeguro = result.TipoSeguro,
                Situacao = result.Situacao,
                PagamentoID = result.PagamentoID,
                PremioLiquido = result.PremioLiquido,
                Comissao = result.Comissao
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
                ClienteID = updatedApolice.ClienteID,
                VigenciaInicio = updatedApolice.VigenciaInicio,
                VigenciaFim = updatedApolice.VigenciaFim,
                SeguradoraID = updatedApolice.SeguradoraID,
                TipoSeguro = updatedApolice.TipoSeguro,
                Situacao = updatedApolice.Situacao,
                PagamentoID = updatedApolice.PagamentoID,
                PremioLiquido = updatedApolice.PremioLiquido,
                Comissao = updatedApolice.Comissao
            };

        }

        public async Task<List<ApoliceGetDTO>> GetAllAsync()
        {
            var apolices = await _apoliceRepository.GetAllAsync();
            return apolices.Select(a => new ApoliceGetDTO
            {
                ClienteID = a.ClienteID,
                VigenciaInicio = a.VigenciaInicio,
                VigenciaFim = a.VigenciaFim,
                SeguradoraID = a.SeguradoraID,
                TipoSeguro = a.TipoSeguro,
                Situacao = a.Situacao,
                PagamentoID = a.PagamentoID,
                PremioLiquido = a.PremioLiquido,
                Comissao = a.Comissao
            }).ToList();
        }

        public Task<List<ApoliceDetailsGetDTO>> GetAllDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ApoliceGetDTO> GetByIdAsync(int id)
        {
            var apolice = await _apoliceRepository.GetByIdAsync(id);
            if (apolice == null)
                throw new NotFoundException("Apolice não encontrada.");
            return new ApoliceGetDTO
            {
                ClienteID = apolice.ClienteID,
                VigenciaInicio = apolice.VigenciaInicio,
                VigenciaFim = apolice.VigenciaFim,
                SeguradoraID = apolice.SeguradoraID,
                TipoSeguro = apolice.TipoSeguro,
                Situacao = apolice.Situacao,
                PagamentoID = apolice.PagamentoID,
                PremioLiquido = apolice.PremioLiquido,
                Comissao = apolice.Comissao
            };                
        }

        public Task<ApoliceDetailsGetDTO> GetDetailsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApoliceGetDTO> UpdateAsync(ApolicePutDTO apolicePutDTO)
        {
            var apolice = await _apoliceRepository.GetByIdAsync(apolicePutDTO.Id);
            if (apolice == null)
                throw new NotFoundException("Apolice não encontrada.");
            var apoliceUpdated = await _apoliceRepository.UpdateAsync(apolice);

            return new ApoliceGetDTO
            {
                ClienteID = apoliceUpdated.ClienteID,
                TipoSeguro = apoliceUpdated.TipoSeguro,
                VigenciaInicio = apoliceUpdated.VigenciaInicio,
                VigenciaFim = apoliceUpdated.VigenciaFim,
                SeguradoraID = apoliceUpdated.SeguradoraID,
                Situacao = apoliceUpdated.Situacao,
                PagamentoID = apoliceUpdated.PagamentoID,
                PremioLiquido = apoliceUpdated.PremioLiquido,
                Comissao = apoliceUpdated.Comissao
            };
        }
    }
}
