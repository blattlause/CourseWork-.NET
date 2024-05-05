using BLL.DependencyInjection;
namespace CourceWork.DependencyInjection
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureApp(this IServiceCollection services, string connectionString)
        {
            services.ConfigureBLL(connectionString);
        }
    }
}
