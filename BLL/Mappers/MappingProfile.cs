using AutoMapper;
using DAL.Models;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Claim, ClaimDTO>();
            CreateMap<Diagnosis, DiagnosisDTO>();
            CreateMap<MedicineCard, MedicineCardDTO>();
            CreateMap<Medicine, MedicineDTO>();
            CreateMap<Note, NoteDTO>();
            CreateMap<Owner, OwnerDTO>();
            CreateMap<Pet, PetDTO>();
            CreateMap<Reception, ReceptionDTO>();
            CreateMap<Service, ServiceDTO>();
            CreateMap<ServiceVisit, ServiceVisitDTO>();
            CreateMap<Species, SpeciesDTO>();
            CreateMap<Vet, VetDTO>();
            CreateMap<Visit, VisitDTO>();
        }
    }
}
