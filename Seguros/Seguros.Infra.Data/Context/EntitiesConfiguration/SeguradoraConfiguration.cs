using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Context.EntitiesConfiguration
{
    public class SeguradoraConfiguration : IEntityTypeConfiguration<Seguradora>
    {
        public void Configure(EntityTypeBuilder<Seguradora> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
