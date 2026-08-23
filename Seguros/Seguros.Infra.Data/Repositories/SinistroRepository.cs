using Microsoft.EntityFrameworkCore;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using Seguros.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Repositories
{
    public class SinistroRepository : ISinistroRepository
    {
        private readonly ApplicationDbContext _context;
        public SinistroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Sinistro> AddAsync(Sinistro sinistro)
        {
            _context.Sinistro.Add(sinistro);
            await _context.SaveChangesAsync();
            return sinistro;
        }

        public async Task<Sinistro> DeleteAsync(int id)
        {
            Sinistro sinistro = await _context.Sinistro.Where(s => s.ID == id).FirstOrDefaultAsync();
            if (sinistro == null)
                return null;
            _context.Sinistro.Remove(sinistro);
            await _context.SaveChangesAsync();
            return sinistro;
        }

        public async Task<List<Sinistro>> GetAllAsync()
        {
            return await _context.Sinistro.ToListAsync();
        }

        public async Task<Sinistro> GetByIdAsync(int id)
        {
            return await _context.Sinistro.Where(s => s.ID == id).FirstOrDefaultAsync();
        }

        public async Task<Sinistro> UpdateAsync(Sinistro sinistro)
        {
            _context.Sinistro.Update(sinistro);
            await _context.SaveChangesAsync();
            return sinistro;
        }
    }
}
