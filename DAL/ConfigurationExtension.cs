using Microsoft.Extensions.DependencyInjection;
using DAL.Repositories;
using DAL.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public static class ConfigurationExtension
    {
        public static void ConfigureDAL(this IServiceCollection services, string connection)
        {
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connection));

            services.AddScoped(typeof(IClaimRepository), typeof(ClaimRepository));
            services.AddScoped(typeof(IDiagnosisRepository), typeof(DiagnosisRepository));
            services.AddScoped(typeof(IMedicineCardRepository), typeof(MedicineCardRepository));
            services.AddScoped(typeof(IMedicineRepository), typeof(MedicineRepository));
            services.AddScoped(typeof(INoteRepository), typeof(NoteRepository));
            services.AddScoped(typeof(IReceptionRepository), typeof(ReceptionRepository));
            services.AddScoped(typeof(IOwnerRepository), typeof(OwnerRepository));
            services.AddScoped(typeof(IPetRepository), typeof(PetRepository));
            services.AddScoped(typeof(IServiceRepository), typeof(ServiceRepository));
            services.AddScoped(typeof(IServiceVisitRepository), typeof(ServiceVisitRepository));
            services.AddScoped(typeof(ISpeciesRepository), typeof(SpeciesRepository));
            services.AddScoped(typeof(IVetRepository), typeof(VetRepository));
            services.AddScoped(typeof(IVisitRepository), typeof(VisitRepository));
        }
    }
}
