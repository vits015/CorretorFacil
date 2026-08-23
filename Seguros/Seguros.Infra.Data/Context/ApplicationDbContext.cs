using Microsoft.EntityFrameworkCore;
using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Apolice> Apolice { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Seguradora> Seguradora { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Parcela> Parcela { get; set; }
        public DbSet<Sinistro> Sinistro { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}