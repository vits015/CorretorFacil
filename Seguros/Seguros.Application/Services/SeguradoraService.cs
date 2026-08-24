using Seguros.Application.DTOs.Seguradora;
using Seguros.Application.Interfaces;
using Seguros.Application.Exceptions;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguros.Application.DTOs.Contato;

namespace Seguros.Application.Services
{
    public class SeguradoraService : ISeguradoraService
    {
        private readonly ISeguradoraRepository _seguradoraRepository;
        private readonly IContatoRepository _contatoRepository;

        public SeguradoraService(ISeguradoraRepository seguradoraRepository, IContatoRepository contatoRepository)
        {
            _seguradoraRepository = seguradoraRepository;
            _contatoRepository = contatoRepository;
            
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
                Id = created.Id,
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
                Id = deleted.Id,
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
                    Id = s.Id,
                    Nome = s.Nome
                });
            }

            return dtos;
        }
        public async Task<List<SeguradoraDetailsGetDTO>> GetAllDetailsAsync()
        {
            var seguradoras = await _seguradoraRepository.GetAllAsync();
            var contatosSeguradora = await _contatoRepository.GetAllAsync();
            var dtos = new List<SeguradoraDetailsGetDTO>();

            foreach (var s in seguradoras)
            {
                var contatos = new List<ContatoGetDTO>();
                foreach (var c in contatosSeguradora.Where(c => c.SeguradoraID == s.Id))
                {
                    contatos.Add(new ContatoGetDTO
                    {
                        Id = c.Id,
                        Nome = c.Nome,
                        Descricao = c.Descricao
                    });
                }

                dtos.Add(new SeguradoraDetailsGetDTO
                {
                    Id = s.Id,
                    Nome = s.Nome,
                    Contatos = contatos
                });
            }

            return dtos;
        }

        public async Task<SeguradoraGetDTO> GetByIdAsync(int? id)
        {
            var seguradora = await _seguradoraRepository.GetByIdAsync(id);
            if (seguradora == null)
                return null;

            return new SeguradoraGetDTO
            {
                Id = seguradora.Id,
                Nome = seguradora.Nome
            };
        }

        public async Task<SeguradoraDetailsGetDTO> GetDetailsByIdAsync(int id)
        {
            var seguradora = await _seguradoraRepository.GetByIdAsync(id);
            if (seguradora == null)
                return null;
            var contatosSeguradora = await _contatoRepository.GetAllAsync();
            contatosSeguradora.Where(c => c.SeguradoraID == seguradora.Id);
            var contatos = new List<ContatoGetDTO>();
            foreach (var c in contatosSeguradora)
            {
                contatos.Add(new ContatoGetDTO
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Descricao = c.Descricao
                });
            }

            return new SeguradoraDetailsGetDTO
            {
                Id = seguradora.Id,
                Nome = seguradora.Nome,
                Contatos = contatos                                    
            };
        }

        public async Task<SeguradoraGetDTO> UpdateAsync(SeguradoraPutDTO seguradoraPutDTO)
        {
            var seguradora = new Seguradora
            {
                Id = seguradoraPutDTO.Id,
                Nome = seguradoraPutDTO.Nome
            };

            var updated = await _seguradoraRepository.UpdateAsync(seguradora);
            if (updated == null)
                return null;

            return new SeguradoraGetDTO
            {
                Id = updated.Id,
                Nome = updated.Nome
            };
        }
    }
}
