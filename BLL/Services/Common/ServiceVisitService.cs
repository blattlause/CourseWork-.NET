using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Intefaces;
using DAL.Models;


namespace BLL.Services.Common
{
    internal class ServiceVisitService: IServiceVisitService
    {
        private readonly IServiceVisitRepository repository;
        private readonly IMapper mapper;

        public ServiceVisitService(IServiceVisitRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(ServiceVisitDTO entity)
        {
            ServiceVisit serviceVisit = mapper.Map<ServiceVisit>(entity);
            repository.Add(serviceVisit);
        }

        public IList<ServiceVisitDTO> GetAll()
        {
            IList<ServiceVisit> serviceVisits = repository.GetAll();
            return serviceVisits.Select(c => mapper.Map<ServiceVisitDTO>(c)).ToList();
        }

        public ServiceVisitDTO? GetById(int id)
        {
            ServiceVisit? serviceVisit = repository.GetById(id);
            return mapper.Map<ServiceVisitDTO>(serviceVisit);
        }

        public void Remove(ServiceVisitDTO entity)
        {
            ServiceVisit serviceVisit = mapper.Map<ServiceVisit>(entity);
            repository.Remove(serviceVisit.Id);
        }

        public void Update(ServiceVisitDTO entity)
        {
            ServiceVisit serviceVisit = mapper.Map<ServiceVisit>(entity);
            repository.Update(serviceVisit);
        }
    }
}
