using Microsoft.EntityFrameworkCore;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using Seguros.Infra.Data.Context;

namespace Seguros.Infra.Data.Repositories;

public class ArquivoApoliceRepository : IArquivoApoliceRepository
{
    private readonly ApplicationDbContext _context;

    public ArquivoApoliceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ArquivoApolice> AddAsync(ArquivoApolice arquivo)
    {
        _context.ArquivoApolice.Add(arquivo);
        await _context.SaveChangesAsync();
        return arquivo;
    }

    public Task<ArquivoApolice?> GetByIdAsync(int id)
    {
        return _context.ArquivoApolice
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && !x.Excluido);
    }

    public Task<List<ArquivoApolice>> GetByApoliceIdAsync(int apoliceId)
    {
        return _context.ArquivoApolice
            .AsNoTracking()
            .Where(x => x.ApoliceId == apoliceId && !x.Excluido)
            .OrderByDescending(x => x.DataUpload)
            .ToListAsync();
    }

    public async Task<ArquivoApolice?> DeleteAsync(int id)
    {
        var arquivo = await _context.ArquivoApolice
            .FirstOrDefaultAsync(x => x.Id == id && !x.Excluido);

        if (arquivo == null)
            return null;

        arquivo.Excluido = true;
        await _context.SaveChangesAsync();

        return arquivo;
    }
}
