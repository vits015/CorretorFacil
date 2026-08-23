using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Context.EntitiesConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);            
            builder.Property(x=> x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.CPF).HasMaxLength(11);
            builder.Property(x => x.CNPJ).HasMaxLength(14);
            builder.Property(x => x.Excluido).IsRequired();
            builder.Property(x => x.EstadoCivil).HasMaxLength(50);
            builder.Property(x => x.Sexo).HasMaxLength(20);
            builder.Property(x => x.Profissao).HasMaxLength(100);
        }
    }
}
