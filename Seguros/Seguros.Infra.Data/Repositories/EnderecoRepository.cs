using Microsoft.EntityFrameworkCore;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using Seguros.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ApplicationDbContext _context;
        public EnderecoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Endereco> AddAsync(Endereco endereco)
        {
            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<Endereco> DeleteAsync(int id)
        {
            Endereco endereco = await _context.Endereco.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (endereco == null)
                return null;
            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<List<Endereco>> GetAllAsync()
        {
            return await _context.Endereco.ToListAsync();
        }

        public async Task<Endereco> GetByIdAsync(int id)
        {
            return await _context.Endereco.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Endereco> UpdateAsync(Endereco endereco)
        {
            _context.Endereco.Update(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }
    }
}
