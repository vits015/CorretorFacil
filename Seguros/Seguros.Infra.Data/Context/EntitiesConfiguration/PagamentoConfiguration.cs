using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Context.EntitiesConfiguration
{
    public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TipoPagamento)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(t => t.ValorTotal) .IsRequired() .HasMaxLength(50);
            builder.Property(t => t.QuantidadeParcelas).IsRequired().HasMaxLength(50);            
        }
    }
}
