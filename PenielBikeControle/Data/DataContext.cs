﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PenielBikeControle.Models;

namespace PenielBikeControle.Data
{
    public class DataContext : IdentityDbContext<Usuario>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Venda>().HasQueryFilter(x => x.Removido == false);
            modelBuilder.Entity<Cliente>().HasQueryFilter(x => x.Removido == false);
            modelBuilder.Entity<Funcionario>().HasQueryFilter(x => x.Removido == false);
            modelBuilder.Entity<TipoProdutoEstoque>().HasQueryFilter(x => x.Removido == false);
            modelBuilder.Entity<ProdutoEstoque>().HasQueryFilter(x => x.Removido == false);
            modelBuilder.Entity<ProdutoCliente>().HasQueryFilter(x => x.Removido == false);
        }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<TipoProdutoEstoque> TiposProduto { get; set; }
        public DbSet<ProdutoEstoque> ProdutosEstoque { get; set; }
        public DbSet<ProdutoCliente> ProdutosCliente { get; set; }
    }
}
