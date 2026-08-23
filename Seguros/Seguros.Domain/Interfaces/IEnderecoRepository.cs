using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco> GetByIdAsync(int id);
        Task<List<Endereco>> GetAllAsync();
        Task<Endereco> AddAsync(Endereco endereco);
        Task<Endereco> UpdateAsync(Endereco endereco);
        Task<Endereco> DeleteAsync(int id);
    }
}
