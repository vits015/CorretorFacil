using Seguros.Application.DTOs.Cliente;
using Seguros.Application.DTOs.Endereco;
using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task<EnderecoGetDTO> GetByIdAsync(int id);
        Task<List<EnderecoGetDTO>> GetAllAsync();
        Task<EnderecoGetDTO> AddAsync(EnderecoPostDTO enderecoPostDTO);
        Task<EnderecoGetDTO> UpdateAsync(EnderecoPutDTO enderecoPutDTO);
        Task<EnderecoGetDTO> DeleteAsync(int id);
    }
}
