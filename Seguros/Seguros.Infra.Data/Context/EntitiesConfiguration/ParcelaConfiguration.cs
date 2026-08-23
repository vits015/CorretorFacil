using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Context.EntitiesConfiguration
{
    public class ParcelaConfiguration : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PagamentoID).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.DataVencimento);            
        }
    }
}
