namespace Seguros.Application.DTOs.ArquivoApolice;

public class ArquivoApolicePostDTO
{
    public string NomeArquivo { get; set; } = string.Empty;
    public string CaminhoArquivo { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public long? TamanhoBytes { get; set; }
}
