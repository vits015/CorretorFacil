using Seguros.Application.DTOs.Endereco;
using Seguros.Application.Interfaces;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using Seguros.Application.Exceptions;

namespace Seguros.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IClienteRepository _clienteRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository, IClienteRepository clienteRepository)
        {
            _enderecoRepository = enderecoRepository;
            _clienteRepository = clienteRepository;
        }
        public async Task<EnderecoGetDTO> AddAsync(EnderecoPostDTO enderecoPostDTO)
        {
            var cliente = await _clienteRepository.GetByIdAsync(enderecoPostDTO.ClienteId);
            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado");
            var endereco = new Endereco
            {
                Logradouro = enderecoPostDTO.Logradouro,
                CEP = enderecoPostDTO.CEP,
                Numero = enderecoPostDTO.Numero,
                Bairro = enderecoPostDTO.Bairro,
                Cidade = enderecoPostDTO.Cidade,
                Estado = enderecoPostDTO.Estado,
                Complemento = enderecoPostDTO.Complemento,
                Nome = enderecoPostDTO.Nome,
                Cliente = cliente
            };
            var created = await _enderecoRepository.AddAsync(endereco);
            return new EnderecoGetDTO
            {
                Id = created.Id,
                Logradouro = created.Logradouro,
                CEP = created.CEP,
                Numero = created.Numero,
                Bairro = created.Bairro,
                Cidade = created.Cidade,
                Estado = created.Estado,
                Complemento = created.Complemento,
                Nome = created.Nome
            };
        }

        public async Task<EnderecoGetDTO> DeleteAsync(int id)
        {
            var deleted = await _enderecoRepository.DeleteAsync(id);
            if (deleted == null)
                return null;
            return new EnderecoGetDTO
            {
                Id = deleted.Id,
                Logradouro = deleted.Logradouro,
                CEP = deleted.CEP,
                Numero = deleted.Numero,
                Bairro = deleted.Bairro,
                Cidade = deleted.Cidade,
                Estado = deleted.Estado,
                Complemento = deleted.Complemento,
                Nome = deleted.Nome
            };
        }

        public async Task<List<EnderecoGetDTO>> GetAllAsync()
        {
            var enderecos = await _enderecoRepository.GetAllAsync();
            var dtos = new List<EnderecoGetDTO>();
            foreach (var e in enderecos)
            {
                dtos.Add(new EnderecoGetDTO
                {
                    Id = e.Id,
                    Logradouro = e.Logradouro,
                    CEP = e.CEP,
                    Numero = e.Numero,
                    Bairro = e.Bairro,
                    Cidade = e.Cidade,
                    Estado = e.Estado,
                    Complemento = e.Complemento,
                    Nome = e.Nome,
                    ClienteID = e.ClienteId
                });
            }
            return dtos;
        }

        public async Task<EnderecoGetDTO> GetByIdAsync(int id)
        {
            var endereco = await _enderecoRepository.GetByIdAsync(id);
            if (endereco == null)
                return null;
            return new EnderecoGetDTO
            {
                Id = endereco.Id,
                Logradouro = endereco.Logradouro,
                CEP = endereco.CEP,
                Numero = endereco.Numero,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado,
                Complemento = endereco.Complemento,
                Nome = endereco.Nome
            };
        }

        public async Task<EnderecoGetDTO> UpdateAsync(EnderecoPutDTO enderecoPutDTO)
        {
            var endereco = new Endereco
            {
                Id = enderecoPutDTO.Id,
                Logradouro = enderecoPutDTO.Logradouro,
                CEP = enderecoPutDTO.CEP,
                Numero = enderecoPutDTO.Numero,
                Bairro = enderecoPutDTO.Bairro,
                Cidade = enderecoPutDTO.Cidade,
                Estado = enderecoPutDTO.Estado,
                Complemento = enderecoPutDTO.Complemento,
                Nome = enderecoPutDTO.Nome
            };
            var updated = await _enderecoRepository.UpdateAsync(endereco);
            if (updated == null)
                return null;
            return new EnderecoGetDTO
            {
                Id = updated.Id,
                Logradouro = updated.Logradouro,
                CEP = updated.CEP,
                Numero = updated.Numero,
                Bairro = updated.Bairro,
                Cidade = updated.Cidade,
                Estado = updated.Estado,
                Complemento = updated.Complemento,
                Nome = updated.Nome
            };
        }
    }
}
