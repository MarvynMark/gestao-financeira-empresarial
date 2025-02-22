using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PenielBikeControle.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            // Carrega a configuração do appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Define o diretório base
                .AddJsonFile("appsettings.json") // Adiciona o arquivo de configuração
                .Build();

            // Obtém a string de conexão
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configura o DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );

            return new DataContext(optionsBuilder.Options);
        }
    }
}
