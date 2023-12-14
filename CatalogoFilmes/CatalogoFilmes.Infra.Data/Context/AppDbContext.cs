using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoFilmes.Domain.Entities;

namespace CatalogoFilmes.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Filme>().HasKey(p => p.Id);
            modelBuilder.Entity<Filme>().Property(p => p.Titulo).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Filme>().Property(p => p.Descricao).IsRequired().HasMaxLength(180);
            modelBuilder.Entity<Filme>().Property(p => p.Lancamento).IsRequired();
            modelBuilder.Entity<Filme>().Property(p => p.Diretor).IsRequired().HasMaxLength(50);

        }
    }
}
