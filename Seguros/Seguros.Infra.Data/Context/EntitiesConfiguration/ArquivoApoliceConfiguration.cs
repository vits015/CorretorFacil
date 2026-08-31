using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seguros.Domain.Entities;

namespace Seguros.Infra.Data.Context.EntitiesConfiguration;

public class ArquivoApoliceConfiguration : IEntityTypeConfiguration<ArquivoApolice>
{
    public void Configure(EntityTypeBuilder<ArquivoApolice> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.NomeArquivo)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.CaminhoArquivo)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(x => x.ContentType)
            .HasMaxLength(150)
            .IsRequired(false);

        builder.Property(x => x.TamanhoBytes)
            .IsRequired(false);

        builder.Property(x => x.DataUpload)
            .IsRequired();

        builder.Property(x => x.Excluido)
            .IsRequired();

        builder.HasOne(x => x.Apolice)
            .WithMany(x => x.Arquivos)
            .HasForeignKey(x => x.ApoliceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.ApoliceId, x.CaminhoArquivo })
            .IsUnique();
    }
}
