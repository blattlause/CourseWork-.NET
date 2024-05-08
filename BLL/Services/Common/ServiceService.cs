using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Intefaces;
using DAL.Models;

namespace BLL.Services.Common
{
    internal class ServiceService: IServiceService
    {
        private readonly IServiceRepository repository;
        private readonly IMapper mapper;

        public ServiceService(IServiceRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(ServiceDTO entity)
        {
            Service service = mapper.Map<Service>(entity);
            repository.Add(service);
        }

        public IList<ServiceDTO> GetAll()
        {
            IList<Service> services = repository.GetAll();
            return services.Select(c => mapper.Map<ServiceDTO>(c)).ToList();
        }

        public ServiceDTO? GetById(int id)
        {
            Service? service = repository.GetById(id);
            return mapper.Map<ServiceDTO>(service);
        }

        public IEnumerable<ServiceDTO> GetServicesForReception()
        {
            throw new NotImplementedException();
        }

        public void Remove(ServiceDTO entity)
        {
            Service service = mapper.Map<Service>(entity);
            repository.Remove(service.Id);
        }

        public void Update(ServiceDTO entity)
        {
            Service service = mapper.Map<Service>(entity);
            repository.Update(service);
        }
    }
}
