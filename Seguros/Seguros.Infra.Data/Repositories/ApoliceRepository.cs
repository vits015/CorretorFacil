using Microsoft.EntityFrameworkCore;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using Seguros.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Repositories
{
    public class ApoliceRepository : IApoliceRepository
    {
        private readonly ApplicationDbContext _context;
        public ApoliceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Apolice> AddAsync(Apolice apolice)
        {
            _context.Apolice.Add(apolice);
            await _context.SaveChangesAsync();
            return apolice;
        }

        public async Task<Apolice> DeleteAsync(int id)
        {
            var apolice = await _context.Apolice.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (apolice == null)
                return null;
            apolice.Excluido = true;
            _context.Apolice.Update(apolice);
            await _context.SaveChangesAsync();
            return apolice;
        }

        public async Task<List<Apolice>> GetAllAsync()
        {
            return await _context.Apolice.ToListAsync();
        }

        public async Task<Apolice> GetByIdAsync(int id)
        {
            return await _context.Apolice.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Apolice> UpdateAsync(Apolice apolice)
        {
            _context.Apolice.Update(apolice);
            await _context.SaveChangesAsync();
            return apolice;
        }
    }
}
