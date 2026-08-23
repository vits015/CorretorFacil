using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Context.EntitiesConfiguration
{
    public class SinistroConfiguration : IEntityTypeConfiguration<Sinistro>
    {
        public void Configure(EntityTypeBuilder<Sinistro> builder)
        {
            builder.HasKey(x => x.ID);       
            builder.Property(x => x.DataOcorrencia).IsRequired();
            builder.Property(x => x.NumeroSinistro).HasMaxLength(20).IsRequired();
        }
    }
}
