using Microsoft.EntityFrameworkCore;
using Microsservices.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsservices.Products.Infra.Context
{
    public class ProductDataContext : DbContext
    {
        public ProductDataContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<StatusProduto> StatusProdutos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureProductEntity(builder);
            ConfigureStatusProductEntity(builder);
            base.OnModelCreating(builder);
        }

        private void ConfigureProductEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Produto>()
                .ToTable("produto");

            modelBuilder.Entity<Produto>()
                .Property(p => p.Id)
                .HasColumnName("produtoId")
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Produto>()
                .Property(p => p.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("varchar(200)");

            modelBuilder.Entity<Produto>()
                .Property(p => p.DataCadastro)
                .HasColumnName("dataCadastro")
                .HasColumnType("datetime");

            modelBuilder.Entity<Produto>()
                .Property(p => p.DataAtualizacao)
                .HasColumnName("dataAtualizacao")
                .HasColumnType("datetime");

            modelBuilder.Entity<Produto>()
                .Property(p => p.StatusProdutoId)
                .HasColumnName("statusProdutoId")
                .HasColumnType("int");

        }

        private void ConfigureStatusProductEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusProduto>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<StatusProduto>()
                .ToTable("statusProduto");

            modelBuilder.Entity<StatusProduto>()
                .Property(p => p.Id)
                .HasColumnName("statusProdutoId")
                .HasColumnType("int");

            modelBuilder.Entity<StatusProduto>()
                .Property(s => s.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("varchar(100)");

        }
    }
}
