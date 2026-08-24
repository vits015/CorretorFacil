using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Context.EntitiesConfiguration
{
    public class ApoliceConfiguration
    {
        public void Configure(EntityTypeBuilder<Apolice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClienteID).IsRequired();
            builder.Property(x => x.VigenciaInicio).IsRequired();
            builder.Property(x => x.VigenciaFim).IsRequired();
            builder.Property(x => x.SeguradoraID).IsRequired();
            builder.Property(x => x.TipoSeguro).IsRequired();            
            builder.Property(x => x.Produto).IsRequired();
            builder.Property(x => x.PagamentoID).IsRequired();
            builder.Property(x => x.PremioLiquido).IsRequired();
            builder.Property(x => x.Comissao).IsRequired();
            builder.Property(x => x.Excluido).IsRequired();
        }
    }
}
