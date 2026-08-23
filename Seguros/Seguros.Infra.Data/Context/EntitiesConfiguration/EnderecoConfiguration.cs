using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Context.EntitiesConfiguration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Logradouro).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Numero).HasMaxLength(10);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CEP).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Complemento).HasMaxLength(200);
            builder.HasOne(e => e.Cliente)
                .WithMany(x => x.Enderecos)
                .HasForeignKey(x => x.ClienteId)                
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
