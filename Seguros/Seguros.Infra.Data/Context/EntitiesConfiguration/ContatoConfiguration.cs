using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Context.EntitiesConfiguration
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.HasOne<Cliente>()
                .WithMany(c => c.Contatos)
                .HasForeignKey(x => x.ClienteID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull); // ou Restrict
            builder.HasOne<Seguradora>()
                .WithMany(s => s.Contatos)
                .HasForeignKey(x => x.SeguradoraID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100);                           
        }
    }
}
