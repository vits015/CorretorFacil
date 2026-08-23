using Microsoft.EntityFrameworkCore;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using Seguros.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly ApplicationDbContext _context;
        public PagamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pagamento> AddAsync(Pagamento pagamento)
        {
            _context.Pagamento.Add(pagamento);
            await _context.SaveChangesAsync();
            return pagamento;
        }

        public async Task<Pagamento> DeleteAsync(int id)
        {
            Pagamento pagamento = await _context.Pagamento.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (pagamento == null)
                return null;
            _context.Pagamento.Remove(pagamento);
            await _context.SaveChangesAsync();
            return pagamento;
        }

        public async Task<List<Pagamento>> GetAllAsync()
        {
            return await _context.Pagamento.ToListAsync();
        }

        public async Task<Pagamento> GetByIdAsync(int id)
        {
            return await _context.Pagamento.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Pagamento> UpdateAsync(Pagamento pagamento)
        {
            _context.Pagamento.Update(pagamento);
            await _context.SaveChangesAsync();
            return pagamento;
        }
    }
}
