using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Intefaces;
using DAL.Models;


namespace BLL.Services.Common
{
    internal class VetService: IVetService
    {
        private readonly IVetRepository repository;
        private readonly IMapper mapper;

        public VetService(IVetRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(VetDTO entity)
        {
            Vet vet = mapper.Map<Vet>(entity);
            repository.Add(vet);
        }

        public IList<VetDTO> GetAll()
        {
            IList<Vet> vets = repository.GetAll();
            return vets.Select(c => mapper.Map<VetDTO>(c)).ToList();
        }

        public VetDTO? GetById(int id)
        {
            Vet? vet = repository.GetById(id);
            return mapper.Map<VetDTO>(vet);
        }

        public void Remove(VetDTO entity)
        {
            Vet vet = mapper.Map<Vet>(entity);
            repository.Remove(vet.Id);
        }

        public void Update(VetDTO entity)
        {
            Vet vet = mapper.Map<Vet>(entity);
            repository.Update(vet);
        }
    }
}
