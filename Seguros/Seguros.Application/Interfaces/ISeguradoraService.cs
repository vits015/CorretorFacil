using Seguros.Application.DTOs.Seguradora;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.Interfaces
{
    public interface ISeguradoraService
    {
        Task<SeguradoraGetDTO> GetByIdAsync(int? id);
        Task<SeguradoraDetailsGetDTO> GetDetailsByIdAsync(int id);
        Task<List<SeguradoraGetDTO>> GetAllAsync();
        Task<List<SeguradoraDetailsGetDTO>> GetAllDetailsAsync();
        Task<SeguradoraGetDTO> AddAsync(SeguradoraPostDTO seguradoraPostDTO);
        Task<SeguradoraGetDTO> UpdateAsync(SeguradoraPutDTO seguradoraPutDTO);
        Task<SeguradoraGetDTO> DeleteAsync(int id);
    }
}
