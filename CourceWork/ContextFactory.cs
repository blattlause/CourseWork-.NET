using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace CourceWork
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContextUI>
    {
        public ApplicationDbContextUI CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
        .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContextUI>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new ApplicationDbContextUI(builder.Options);
        }
    }
}
