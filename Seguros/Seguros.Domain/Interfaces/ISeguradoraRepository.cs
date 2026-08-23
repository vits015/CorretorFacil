using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Domain.Interfaces
{
    public interface ISeguradoraRepository
    {
        Task<Seguradora> GetByIdAsync(int id);
        Task<List<Seguradora>> GetAllAsync();
        Task<Seguradora> AddAsync(Seguradora seguradora);
        Task<Seguradora> UpdateAsync(Seguradora seguradora);
        Task<Seguradora> DeleteAsync(int id);
    }
}
