using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Domain.Interfaces
{
    public interface IParcelaRepository
    {
        Task<Parcela> GetByIdAsync(int id);
        Task<List<Parcela>> GetAllAsync();
        Task<Parcela> AddAsync(Parcela parcela);
        Task<Parcela> UpdateAsync(Parcela parcela);
        Task<Parcela> DeleteAsync(int id);
    }
}
