using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Domain.Interfaces
{
    public interface IApoliceRepository
    {
        Task<Apolice> GetByIdAsync(int id);
        Task<List<Apolice>> GetAllAsync();
        Task<Apolice> AddAsync(Apolice apolice);
        Task<Apolice> UpdateAsync(Apolice apolice);
        Task<Apolice> DeleteAsync(int id);
    }
}
