using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Intefaces;
using DAL.Models;

namespace BLL.Receptions.Common
{
    internal class ReceptionReception: IReceptionService
    {
        private readonly IReceptionRepository repository;
        private readonly IMapper mapper;

        public ReceptionReception(IReceptionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(ReceptionDTO entity)
        {
            Reception reception = mapper.Map<Reception>(entity);
            repository.Add(reception);
        }

        public IList<ReceptionDTO> GetAll()
        {
            IList<Reception> receptions = repository.GetAll();
            return receptions.Select(c => mapper.Map<ReceptionDTO>(c)).ToList();
        }

        public IEnumerable<ReceptionDTO> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public ReceptionDTO? GetById(int id)
        {
            Reception? reception = repository.GetById(id);
            return mapper.Map<ReceptionDTO>(reception);
        }

        public IEnumerable<ReceptionDTO> GetByOwner(int idOwner)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReceptionDTO> GetByVet(int idVet)
        {
            throw new NotImplementedException();
        }

        public void Remove(ReceptionDTO entity)
        {
            Reception reception = mapper.Map<Reception>(entity);
            repository.Remove(reception.Id);
        }

        public void Update(ReceptionDTO entity)
        {
            Reception reception = mapper.Map<Reception>(entity);
            repository.Update(reception);
        }
    }
}
