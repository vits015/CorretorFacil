using Seguros.Application.DTOs.Seguradora;
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
    public class SeguradoraService : ISeguradoraService
    {
        private readonly ISeguradoraRepository _seguradoraRepository;

        public SeguradoraService(ISeguradoraRepository seguradoraRepository)
        {
            _seguradoraRepository = seguradoraRepository;
        }

        public async Task<SeguradoraGetDTO> AddAsync(SeguradoraPostDTO seguradoraPostDTO)
        {
            var seguradora = new Seguradora
            {
                Nome = seguradoraPostDTO.Nome
            };

            var created = await _seguradoraRepository.AddAsync(seguradora);
            return new SeguradoraGetDTO
            {
                ID = created.ID,
                Nome = created.Nome
            };
        }

        public async Task<SeguradoraGetDTO> DeleteAsync(int id)
        {
            var deleted = await _seguradoraRepository.DeleteAsync(id);
            if (deleted == null)
                return null;

            return new SeguradoraGetDTO
            {
                ID = deleted.ID,
                Nome = deleted.Nome
            };
        }

        public async Task<List<SeguradoraGetDTO>> GetAllAsync()
        {
            var seguradoras = await _seguradoraRepository.GetAllAsync();
            var dtos = new List<SeguradoraGetDTO>();

            foreach (var s in seguradoras)
            {
                dtos.Add(new SeguradoraGetDTO
                {
                    ID = s.ID,
                    Nome = s.Nome
                });
            }

            return dtos;
        }

        public async Task<SeguradoraGetDTO> GetByIdAsync(int id)
        {
            var seguradora = await _seguradoraRepository.GetByIdAsync(id);
            if (seguradora == null)
                return null;

            return new SeguradoraGetDTO
            {
                ID = seguradora.ID,
                Nome = seguradora.Nome
            };
        }

        public async Task<SeguradoraGetDTO> UpdateAsync(SeguradoraPutDTO seguradoraPutDTO)
        {
            var seguradora = new Seguradora
            {
                ID = seguradoraPutDTO.ID,
                Nome = seguradoraPutDTO.Nome
            };

            var updated = await _seguradoraRepository.UpdateAsync(seguradora);
            if (updated == null)
                return null;

            return new SeguradoraGetDTO
            {
                ID = updated.ID,
                Nome = updated.Nome
            };
        }
    }
}
