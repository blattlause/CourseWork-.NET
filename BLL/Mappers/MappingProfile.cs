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
            CreateMap<Claim, ClaimDTO>().ReverseMap();
            CreateMap<Diagnosis, DiagnosisDTO>().ReverseMap();
            CreateMap<MedicineCard, MedicineCardDTO>().ReverseMap();
            CreateMap<Medicine, MedicineDTO>().ReverseMap();
            CreateMap<Note, NoteDTO>().ReverseMap();
            CreateMap<Owner, OwnerDTO>().ReverseMap();
            CreateMap<Pet, PetDTO>().ReverseMap();
            CreateMap<Reception, ReceptionDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<ServiceVisit, ServiceVisitDTO>().ReverseMap();
            CreateMap<Species, SpeciesDTO>().ReverseMap();
            CreateMap<Vet, VetDTO>().ReverseMap();
            CreateMap<Visit, VisitDTO>().ReverseMap();
        }
    }
}
