using Seguros.Application.DTOs.Contato;
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
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IClienteRepository _clienteRepository;

        public ContatoService(IContatoRepository contatoRepository, IClienteRepository clienteRepository)
        {
            _contatoRepository = contatoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<ContatoGetDTO> AddAsync(ContatoPostDTO contatoPostDTO)
        {
            var cliente = await _clienteRepository.GetByIdAsync(contatoPostDTO.ClienteId);
            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado");

            var contato = new Contato
            {
                Nome = contatoPostDTO.Nome,
                Descricao = contatoPostDTO.Descricao,
                ClienteID = contatoPostDTO.ClienteId
            };

            var created = await _contatoRepository.AddAsync(contato);
            return new ContatoGetDTO
            {
                Id = created.Id,
                Nome = created.Nome,
                Descricao = created.Descricao,
                ClienteID = created.ClienteID
            };
        }

        public async Task<ContatoGetDTO> DeleteAsync(int id)
        {
            var deleted = await _contatoRepository.DeleteAsync(id);
            if (deleted == null)
                return null;

            return new ContatoGetDTO
            {
                Id = deleted.Id,
                Nome = deleted.Nome,
                Descricao = deleted.Descricao,
                ClienteID = deleted.ClienteID
            };
        }

        public async Task<List<ContatoGetDTO>> GetAllAsync()
        {
            var contatos = await _contatoRepository.GetAllAsync();
            var dtos = new List<ContatoGetDTO>();

            foreach (var c in contatos)
            {
                dtos.Add(new ContatoGetDTO
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Descricao = c.Descricao,
                    ClienteID = c.ClienteID
                });
            }

            return dtos;
        }

        public async Task<ContatoGetDTO> GetByIdAsync(int id)
        {
            var contato = await _contatoRepository.GetByIdAsync(id);
            if (contato == null)
                return null;

            return new ContatoGetDTO
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Descricao = contato.Descricao,
                ClienteID = contato.ClienteID
            };
        }

        public async Task<ContatoGetDTO> UpdateAsync(ContatoPutDTO contatoPutDTO)
        {
            var contato = new Contato
            {
                Id = contatoPutDTO.Id,
                Nome = contatoPutDTO.Nome,
                Descricao = contatoPutDTO.Descricao
            };

            var updated = await _contatoRepository.UpdateAsync(contato);
            if (updated == null)
                return null;

            return new ContatoGetDTO
            {
                Id = updated.Id,
                Nome = updated.Nome,
                Descricao = updated.Descricao,
                ClienteID = updated.ClienteID
            };
        }
    }
}
