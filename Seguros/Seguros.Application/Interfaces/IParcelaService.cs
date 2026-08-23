using Seguros.Application.DTOs.Parcela;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.Interfaces
{
    public interface IParcelaService
    {
        Task<ParcelaGetDTO> GetByIdAsync(int id);
        Task<List<ParcelaGetDTO>> GetAllAsync();
        Task<ParcelaGetDTO> AddAsync(ParcelaPostDTO parcelaPostDTO);
        Task<ParcelaGetDTO> UpdateAsync(ParcelaPutDTO parcelaPutDTO);
        Task<ParcelaGetDTO> DeleteAsync(int id);
    }
}
