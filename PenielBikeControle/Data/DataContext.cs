
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
            // connect to mysql with connection string from app settings
            if (!options.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("db_penielbikecontrole");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));


            }
        }

        public DbSet<Venda> Vendas { get; set; }




    }
}
