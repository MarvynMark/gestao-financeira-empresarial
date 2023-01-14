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

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<TipoProduto> TiposProduto { get; set; }
        public DbSet<ProdutoEstoque> ProdutosEstoque { get; set; }
    }
}
