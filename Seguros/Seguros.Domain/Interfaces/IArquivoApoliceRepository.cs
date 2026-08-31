using Seguros.Domain.Entities;

namespace Seguros.Domain.Interfaces;

public interface IArquivoApoliceRepository
{
    Task<ArquivoApolice> AddAsync(ArquivoApolice arquivo);
    Task<ArquivoApolice?> GetByIdAsync(int id);
    Task<List<ArquivoApolice>> GetByApoliceIdAsync(int apoliceId);
}
