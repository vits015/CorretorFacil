using Microsoft.EntityFrameworkCore;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using Seguros.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ApplicationDbContext _context;
        public ContatoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Contato> AddAsync(Contato contato)
        {
            _context.Contato.Add(contato);
            await _context.SaveChangesAsync();
            return contato;
        }

        public async Task<Contato> DeleteAsync(int id)
        {
            Contato contato = await _context.Contato.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (contato == null)
                return null;
            _context.Contato.Remove(contato);
            await _context.SaveChangesAsync();
            return contato;
        }

        public async Task<List<Contato>> GetAllAsync()
        {
            return await _context.Contato.ToListAsync();
        }

        public async Task<Contato> GetByIdAsync(int? id)
        {
            return await _context.Contato.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Contato> UpdateAsync(Contato contato)
        {
            _context.Contato.Update(contato);
            await _context.SaveChangesAsync();
            return contato;
        }
    }
}
