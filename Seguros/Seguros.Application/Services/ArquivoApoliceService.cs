using Seguros.Application.DTOs.ArquivoApolice;
using Seguros.Application.Exceptions;
using Seguros.Application.Interfaces;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;

namespace Seguros.Application.Services;

public class ArquivoApoliceService : IArquivoApoliceService
{
    private readonly IArquivoApoliceRepository _arquivoRepository;
    private readonly IApoliceRepository _apoliceRepository;

    public ArquivoApoliceService(
        IArquivoApoliceRepository arquivoRepository,
        IApoliceRepository apoliceRepository)
    {
        _arquivoRepository = arquivoRepository;
        _apoliceRepository = apoliceRepository;
    }

    public async Task<ArquivoApoliceGetDTO> AddAsync(
        int apoliceId,
        ArquivoApolicePostDTO arquivoDTO)
    {
        var apolice = await _apoliceRepository.GetByIdAsync(apoliceId);

        if (apolice == null || apolice.Excluido)
            throw new NotFoundException("Apolice não encontrada.");

        if (string.IsNullOrWhiteSpace(arquivoDTO.CaminhoArquivo))
            throw new BadRequestException("O caminho do arquivo é obrigatório.");

        var prefixoEsperado = $"apolices/{apoliceId}/";

        if (!arquivoDTO.CaminhoArquivo.StartsWith(
                prefixoEsperado,
                StringComparison.OrdinalIgnoreCase))
        {
            throw new BadRequestException(
                "O caminho do arquivo não pertence à apólice.");
        }

        var arquivo = new ArquivoApolice
        {
            ApoliceId = apoliceId,
            NomeArquivo = Path.GetFileName(arquivoDTO.NomeArquivo),
            CaminhoArquivo = arquivoDTO.CaminhoArquivo,
            ContentType = arquivoDTO.ContentType,
            TamanhoBytes = arquivoDTO.TamanhoBytes
        };

        var criado = await _arquivoRepository.AddAsync(arquivo);
        return MapToDTO(criado);
    }

    public async Task<ArquivoApoliceGetDTO> GetByIdAsync(
        int apoliceId,
        int arquivoId)
    {
        var arquivo = await _arquivoRepository.GetByIdAsync(arquivoId);

        if (arquivo == null || arquivo.ApoliceId != apoliceId)
            throw new NotFoundException("Arquivo não encontrado.");

        return MapToDTO(arquivo);
    }

    public async Task<List<ArquivoApoliceGetDTO>> GetByApoliceIdAsync(
        int apoliceId)
    {
        var apolice = await _apoliceRepository.GetByIdAsync(apoliceId);

        if (apolice == null || apolice.Excluido)
            throw new NotFoundException("Apolice não encontrada.");

        var arquivos =
            await _arquivoRepository.GetByApoliceIdAsync(apoliceId);

        return arquivos.Select(MapToDTO).ToList();
    }

    public async Task<ArquivoApoliceGetDTO> DeleteAsync(
        int apoliceId,
        int arquivoId)
    {
        var arquivo = await _arquivoRepository.GetByIdAsync(arquivoId);

        if (arquivo == null || arquivo.ApoliceId != apoliceId)
            throw new NotFoundException("Arquivo não encontrado.");

        var excluido = await _arquivoRepository.DeleteAsync(arquivoId);

        if (excluido == null)
            throw new NotFoundException("Arquivo não encontrado.");

        return MapToDTO(excluido);
    }

    private static ArquivoApoliceGetDTO MapToDTO(ArquivoApolice arquivo)
    {
        return new ArquivoApoliceGetDTO
        {
            Id = arquivo.Id,
            ApoliceId = arquivo.ApoliceId,
            NomeArquivo = arquivo.NomeArquivo,
            CaminhoArquivo = arquivo.CaminhoArquivo,
            ContentType = arquivo.ContentType,
            TamanhoBytes = arquivo.TamanhoBytes,
            DataUpload = arquivo.DataUpload
        };
    }
}
