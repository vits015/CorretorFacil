using Microsoft.EntityFrameworkCore;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using Seguros.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Repositories
{
    public class SeguradoraRepository : ISeguradoraRepository
    {
        private readonly ApplicationDbContext _context;
        public SeguradoraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Seguradora> AddAsync(Seguradora seguradora)
        {
            _context.Seguradora.Add(seguradora);
            await _context.SaveChangesAsync();
            return seguradora;
        }

        public async Task<Seguradora> DeleteAsync(int id)
        {
            Seguradora seguradora = await _context.Seguradora.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (seguradora == null)
                return null;
            _context.Seguradora.Remove(seguradora);
            await _context.SaveChangesAsync();
            return seguradora;
        }

        public async Task<List<Seguradora>> GetAllAsync()
        {
            return await _context.Seguradora.ToListAsync();
        }

        public async Task<Seguradora> GetByIdAsync(int? id)
        {
            return await _context.Seguradora.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Seguradora> UpdateAsync(Seguradora seguradora)
        {
            _context.Seguradora.Update(seguradora);
            await _context.SaveChangesAsync();
            return seguradora;
        }
    }
}
