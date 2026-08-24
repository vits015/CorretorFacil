using Seguros.Application.DTOs.Cliente;
using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteGetDTO> GetByIdAsync(int? id);
        Task<List<ClienteGetDTO>> GetAllAsync();
        Task<List<ClienteDetailsGetDTO>> GetAllDetailsAsync();
        Task<ClienteDetailsGetDTO> GetDetailsByIdAsync(int id);
        Task<ClienteGetDTO> AddAsync(ClientePostDTO clientePostDTO);
        Task<ClienteGetDTO> UpdateAsync(ClientePutDTO clientePutDTO);
        Task<ClienteGetDTO> DeleteAsync(int id);        
    }
}
