using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Intefaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Common
{
    public class SpeciesService: ISpeciesService
    {
        private readonly ISpeciesRepository repository;
        private readonly IMapper mapper;

        public SpeciesService(ISpeciesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(SpeciesDTO entity)
        {
            Species species = mapper.Map<Species>(entity);
            repository.Add(species);
        }

        public IList<SpeciesDTO> GetAll()
        {
            IList<Species> speciess = repository.GetAll();
            return speciess.Select(c => mapper.Map<SpeciesDTO>(c)).ToList();
        }

        public SpeciesDTO? GetById(int id)
        {
            Species? species = repository.GetById(id);
            return mapper.Map<SpeciesDTO>(species);
        }

        public void Remove(SpeciesDTO entity)
        {
            Species species = mapper.Map<Species>(entity);
            repository.Remove(species.Id);
        }

        public void Update(SpeciesDTO entity)
        {
            Species species = mapper.Map<Species>(entity);
            repository.Update(species);
        }
    }
}
