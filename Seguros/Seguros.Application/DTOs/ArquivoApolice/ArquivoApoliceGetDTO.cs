namespace Seguros.Application.DTOs.ArquivoApolice;

public class ArquivoApoliceGetDTO
{
    public int Id { get; set; }
    public int ApoliceId { get; set; }
    public string NomeArquivo { get; set; } = string.Empty;
    public string CaminhoArquivo { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public long? TamanhoBytes { get; set; }
    public DateTime DataUpload { get; set; }
}
