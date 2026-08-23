using Seguros.Application.DTOs.Sinistro;
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
    public class SinistroService : ISinistroService
    {
        private readonly ISinistroRepository _sinistroRepository;
        private readonly IApoliceRepository _apoliceRepository;

        public SinistroService(ISinistroRepository sinistroRepository, IApoliceRepository apoliceRepository)
        {
            _sinistroRepository = sinistroRepository;
            _apoliceRepository = apoliceRepository;
        }

        public async Task<SinistroGetDTO> AddAsync(SinistroPostDTO sinistroPostDTO)
        {
            var apolice = await _apoliceRepository.GetByIdAsync(sinistroPostDTO.SeguroID);
            if (apolice == null)
                throw new NotFoundException("Apólice não encontrada");

            var sinistro = new Sinistro
            {
                SeguroID = sinistroPostDTO.SeguroID,
                DataOcorrencia = sinistroPostDTO.DataOcorrencia,
                NumeroSinistro = sinistroPostDTO.NumeroSinistro
            };

            var created = await _sinistroRepository.AddAsync(sinistro);
            return MapToGetDTO(created);
        }

        public async Task<SinistroGetDTO> DeleteAsync(int id)
        {
            var deleted = await _sinistroRepository.DeleteAsync(id);
            if (deleted == null)
                return null;

            return MapToGetDTO(deleted);
        }

        public async Task<List<SinistroGetDTO>> GetAllAsync()
        {
            var sinistros = await _sinistroRepository.GetAllAsync();
            var dtos = new List<SinistroGetDTO>();

            foreach (var s in sinistros)
            {
                dtos.Add(MapToGetDTO(s));
            }

            return dtos;
        }

        public async Task<SinistroGetDTO> GetByIdAsync(int id)
        {
            var sinistro = await _sinistroRepository.GetByIdAsync(id);
            if (sinistro == null)
                return null;

            return MapToGetDTO(sinistro);
        }

        public async Task<SinistroGetDTO> UpdateAsync(SinistroPutDTO sinistroPutDTO)
        {
            var apolice = await _apoliceRepository.GetByIdAsync(sinistroPutDTO.SeguroID);
            if (apolice == null)
                throw new NotFoundException("Apólice não encontrada");

            var sinistro = new Sinistro
            {
                ID = sinistroPutDTO.ID,
                SeguroID = sinistroPutDTO.SeguroID,
                DataOcorrencia = sinistroPutDTO.DataOcorrencia,
                NumeroSinistro = sinistroPutDTO.NumeroSinistro
            };

            var updated = await _sinistroRepository.UpdateAsync(sinistro);
            if (updated == null)
                return null;

            return MapToGetDTO(updated);
        }

        private static SinistroGetDTO MapToGetDTO(Sinistro sinistro)
        {
            return new SinistroGetDTO
            {
                ID = sinistro.ID,
                SeguroID = sinistro.SeguroID,
                DataOcorrencia = sinistro.DataOcorrencia,
                NumeroSinistro = sinistro.NumeroSinistro
            };
        }
    }
}
