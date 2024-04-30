using BLL.DTO;
using BLL.Mappers;
using BLL.Receptions.Common;
using BLL.Services.Common;
using BLL.Services.Interfaces;
using DAL;
using DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DependencyInjection
{
    public static class ConfigurationExtension
    {
        public static void ConfigureBLL(this IServiceCollection services, string connection)
        {
            services.ConfigureDAL(connection);
            services.AddAutoMapper(typeof(MappingProfile));

            //services.AddTransient<IService<IDTO>, BaseService<IDTO, IEntity>>();

            services.AddTransient<IClaimService, ClaimService>();
            services.AddTransient<IDiagnosisService, DiagnosisService>();
            services.AddTransient<IMedicineService, MedicineService>();
            services.AddTransient<IMedicineCardService, MedicineCardService>();
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<IOwnerService, OwnerService>();
            services.AddTransient<IPetService, PetService>();
            services.AddTransient<IReceptionService, ReceptionReception>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IServiceVisitService, ServiceVisitService>();
            services.AddTransient<ISpeciesService, SpeciesService>();
            services.AddTransient<IVetService, VetService>();
            services.AddTransient<IVisitService, VisitService>();
        }
    }
}
