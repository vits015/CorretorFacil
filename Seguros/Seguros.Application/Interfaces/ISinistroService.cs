using Seguros.Application.DTOs.Sinistro;        
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.Interfaces
{
    public interface ISinistroService
    {
        Task<SinistroGetDTO> GetByIdAsync(int id);
        Task<List<SinistroGetDTO>> GetAllAsync();
        Task<SinistroGetDTO> AddAsync(SinistroPostDTO sinistroPostDTO);
        Task<SinistroGetDTO> UpdateAsync(SinistroPutDTO sinistroPutDTO);
        Task<SinistroGetDTO> DeleteAsync(int id);
    }
}