using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Domain.Interfaces
{
    public interface IContatoRepository
    {
        Task<Contato> GetByIdAsync(int id);
        Task<List<Contato>> GetAllAsync();
        Task<Contato> AddAsync(Contato contato);
        Task<Contato> UpdateAsync(Contato contato);
        Task<Contato> DeleteAsync(int id);
    }
}
