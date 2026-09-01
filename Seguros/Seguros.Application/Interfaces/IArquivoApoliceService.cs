using Seguros.Application.DTOs.ArquivoApolice;

namespace Seguros.Application.Interfaces;

public interface IArquivoApoliceService
{
    Task<ArquivoApoliceGetDTO> AddAsync(
        int apoliceId,
        ArquivoApolicePostDTO arquivoDTO);

    Task<ArquivoApoliceGetDTO> GetByIdAsync(
        int apoliceId,
        int arquivoId);

    Task<List<ArquivoApoliceGetDTO>> GetByApoliceIdAsync(
        int apoliceId);

    Task<ArquivoApoliceGetDTO> DeleteAsync(
        int apoliceId,
        int arquivoId);
}
