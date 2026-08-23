using Microsoft.EntityFrameworkCore;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using Seguros.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> DeleteAsync(int id)
        {
            var cliente = await _context.Cliente.Where(c => c.Id == id && !c.Excluido).FirstOrDefaultAsync();
            if (cliente == null)            
                return null;            
            cliente.Excluido = true;
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Cliente.Where(c => !c.Excluido).ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Cliente.Where(c => c.Id == id && !c.Excluido).FirstOrDefaultAsync();      
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
