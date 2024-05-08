using Microsoft.EntityFrameworkCore;


namespace DAL
{
    public class ContextFactory
    {
        public static ApplicationDBContext CreateDbContext()
        {
            // Создаем опции для контекста базы данных
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-VDH8U16;Initial Catalog=VetVetClinic;Integrated Security=True; TrustServerCertificate=true");

            // Создаем экземпляр контекста базы данных с использованием опций
            return new ApplicationDBContext(optionsBuilder.Options);
        }
    }
}