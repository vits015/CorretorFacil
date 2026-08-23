using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Context.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Perfil);
            builder.Property(x => x.PasswordHash)
                .IsRequired();
            builder.Property(x => x.PasswordSalt);
            builder.Property(x => x.Excluido)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property<string>(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
