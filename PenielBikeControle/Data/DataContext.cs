using Microsoft.EntityFrameworkCore;
using PenielBikeControle.Models;
using System.Configuration;

namespace PenielBikeControle.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration) => _configuration = configuration;
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("db_penielbikecontrole");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
