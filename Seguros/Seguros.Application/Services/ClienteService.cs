using Seguros.Application.DTOs.Cliente;
using Seguros.Application.DTOs.Contato;
using Seguros.Application.DTOs.Endereco;
using Seguros.Application.Interfaces;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IContatoRepository _contatoRepository;
        public ClienteService(IClienteRepository clienteRepository, IEnderecoRepository enderecoRepository, IContatoRepository contatoRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
            _contatoRepository = contatoRepository;
        }
        public async Task<ClienteGetDTO> AddAsync(ClientePostDTO clientePostDTO)
        {
            var cliente = new Cliente
            {
                Nome = clientePostDTO.Nome,
                CNPJ = clientePostDTO.CNPJ,
                CPF = clientePostDTO.CPF,
                EstadoCivil = clientePostDTO.EstadoCivil,
                Sexo = clientePostDTO.Sexo,
                Profissao = clientePostDTO.Profissao        
            };

            var createdCliente = await _clienteRepository.AddAsync(cliente);
            return new ClienteGetDTO
            {
                Id = createdCliente.Id,
                Nome = cliente.Nome,
                CNPJ = createdCliente.CNPJ,
                CPF= createdCliente.CPF,
                EstadoCivil = createdCliente.EstadoCivil,
                Sexo = createdCliente.Sexo,
                Profissao = createdCliente.Profissao
            };
        }

        public async Task<ClienteGetDTO> DeleteAsync(int id)
        { 
          var deletedCurso = await _clienteRepository.DeleteAsync(id);
            if (deletedCurso == null)
                return null;
            return new ClienteGetDTO
            {
                Id = deletedCurso.Id,
                Nome = deletedCurso.Nome,
                CNPJ = deletedCurso.CNPJ,
                CPF = deletedCurso.CPF,
                EstadoCivil = deletedCurso.EstadoCivil,
                Sexo = deletedCurso.Sexo,
                Profissao = deletedCurso.Profissao
            };
          
        }        

        public async Task<List<ClienteGetDTO>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            var clientesGetDTOs = new List<ClienteGetDTO>();
            foreach (var cliente in clientes)
            {
                clientesGetDTOs.Add(new ClienteGetDTO {
                    Nome = cliente.Nome,
                    CNPJ = cliente.CNPJ,
                    CPF = cliente.CPF,
                    EstadoCivil = cliente.EstadoCivil,
                    Sexo = cliente.Sexo,
                    Profissao = cliente.Profissao
                });
            }
            return clientesGetDTOs;
        }

        public async Task<List<ClienteDetailsGetDTO>> GetAllDetailsAsync()
        {
            var enderecos = await _enderecoRepository.GetAllAsync();            
            var clientes = await _clienteRepository.GetAllAsync();
            var contatos = await _contatoRepository.GetAllAsync();
            var clienteDetailsGetDTOs = new List<ClienteDetailsGetDTO>();
            foreach (var cliente in clientes)
            {
                var enderecosCliente = enderecos.Where(e => e.ClienteId == cliente.Id);
                var contatosCliente = contatos.Where(c => c.ClienteID == cliente.Id);    

                var enderecosDoCliente = new List<EnderecoGetDTO>();
                var contatosDoCliente = new List<ContatoGetDTO>();

                foreach (var e in enderecosCliente)
                {
                    enderecosDoCliente.Add(new EnderecoGetDTO
                    {
                        Id = e.Id,
                        Logradouro = e.Logradouro,
                        Numero = e.Numero,
                        Complemento = e.Complemento,
                        Bairro = e.Bairro,
                        Cidade = e.Cidade,
                        Estado = e.Estado,
                        CEP = e.CEP
                    });
                }
                foreach (var c in contatosCliente)
                {
                    contatosDoCliente.Add(new ContatoGetDTO
                    {
                        Id = c.Id,
                        Nome = c.Nome,
                        Descricao = c.Descricao
                    });
                }

                clienteDetailsGetDTOs.Add(new ClienteDetailsGetDTO
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    CNPJ = cliente.CNPJ,
                    CPF = cliente.CPF,
                    EstadoCivil = cliente.EstadoCivil,
                    Sexo = cliente.Sexo,
                    Profissao = cliente.Profissao,
                    Enderecos = enderecosDoCliente,
                    Contatos = contatosDoCliente
                });
                                
            }
            return clienteDetailsGetDTOs;
        }

        public async Task<ClienteGetDTO> GetByIdAsync(int? id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                return null;
            return new ClienteGetDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                CNPJ = cliente.CNPJ,
                CPF = cliente.CPF,
                EstadoCivil = cliente.EstadoCivil,
                Sexo = cliente.Sexo,
                Profissao = cliente.Profissao,
            };
        }

        public Task<ClienteDetailsGetDTO> GetDetailsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ClienteGetDTO> UpdateAsync(ClientePutDTO clientePutDTO)
        {
            var cliente = new Cliente
            {
                Id = clientePutDTO.Id,
                Nome = clientePutDTO.Nome,
                CPF = clientePutDTO.CPF,
                CNPJ = clientePutDTO.CNPJ,
                EstadoCivil = clientePutDTO.EstadoCivil,
                Sexo = clientePutDTO.Sexo,
                Profissao = clientePutDTO.Profissao
            };
            var updatedCliente = await _clienteRepository.UpdateAsync(cliente);
            if (updatedCliente == null)
                return null;
            return new ClienteGetDTO
            {
                Id = updatedCliente.Id,
                Nome = updatedCliente.Nome,
                CPF = updatedCliente.CPF,
                CNPJ = updatedCliente.CNPJ,
                EstadoCivil = updatedCliente.EstadoCivil,
                Sexo = updatedCliente.Sexo,
                Profissao = updatedCliente.Profissao
            };

        }
    }
}
