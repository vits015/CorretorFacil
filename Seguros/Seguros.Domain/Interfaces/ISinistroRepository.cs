using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Domain.Interfaces
{
    public interface ISinistroRepository    
    {
        Task<Sinistro> GetByIdAsync(int id);
        Task<List<Sinistro>> GetAllAsync();
        Task<Sinistro> AddAsync(Sinistro cliente);
        Task<Sinistro> UpdateAsync(Sinistro cliente);
        Task<Sinistro> DeleteAsync(int id);
    }
}
