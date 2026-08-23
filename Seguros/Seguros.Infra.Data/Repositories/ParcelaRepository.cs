using Microsoft.EntityFrameworkCore;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using Seguros.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Repositories
{
    public class ParcelaRepository : IParcelaRepository
    {
        private readonly ApplicationDbContext _context;
        public ParcelaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Parcela> AddAsync(Parcela parcela)
        {
            _context.Add(parcela);
            await _context.SaveChangesAsync();
            return parcela;
        }

        public async Task<Parcela> DeleteAsync(int id)
        {
            Parcela parcela = await _context.Parcela.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (parcela == null)
                return null;
            _context.Remove(parcela);
            await _context.SaveChangesAsync();
            return parcela;
        }

        public async Task<List<Parcela>> GetAllAsync()
        {
            return await _context.Parcela.ToListAsync();
        }

        public async Task<Parcela> GetByIdAsync(int id)
        {
            return await _context.Parcela.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Parcela> UpdateAsync(Parcela parcela)
        {
            _context.Parcela.Update(parcela);
            await _context.SaveChangesAsync();
            return parcela;
        }
    }
}
