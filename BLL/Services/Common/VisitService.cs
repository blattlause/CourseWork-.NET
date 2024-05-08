using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Intefaces;
using DAL.Models;


namespace BLL.Services.Common
{
    internal class VisitService: IVisitService
    {
        private readonly IVisitRepository repository;
        private readonly IMapper mapper;

        public VisitService(IVisitRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(VisitDTO entity)
        {
            Visit visit = mapper.Map<Visit>(entity);
            repository.Add(visit);
        }

        public IList<VisitDTO> GetAll()
        {
            IList<Visit> visits = repository.GetAll();
            return visits.Select(c => mapper.Map<VisitDTO>(c)).ToList();
        }

        public VisitDTO? GetById(int id)
        {
            Visit? visit = repository.GetById(id);
            return mapper.Map<VisitDTO>(visit);
        }

        public void Remove(VisitDTO entity)
        {
            Visit visit = mapper.Map<Visit>(entity);
            repository.Remove(visit.Id);
        }

        public void Update(VisitDTO entity)
        {
            Visit visit = mapper.Map<Visit>(entity);
            repository.Update(visit);
        }
    }
}
