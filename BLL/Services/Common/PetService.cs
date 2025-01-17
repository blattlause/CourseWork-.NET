﻿using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Intefaces;
using DAL.Models;
using static Azure.Core.HttpHeader;


namespace BLL.Services.Common
{
    internal class PetService: IPetService
    {
        private readonly IPetRepository repository;
        private readonly IMapper mapper;

        public PetService(IPetRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(PetDTO entity)
        {
            Pet pet = mapper.Map<Pet>(entity);
            repository.Add(pet);
        }

        public IList<PetDTO> GetAll()
        {
            IList<Pet> pets = repository.GetAll();
            return mapper.Map<IList<PetDTO>>(pets);
        }

        public PetDTO? GetById(int id)
        {
            Pet? pet = repository.GetById(id);
            return mapper.Map<PetDTO>(pet);
        }

        public IEnumerable<PetDTO> GetPetsByOwner()
        {
            throw new NotImplementedException();
        }

        public void Remove(PetDTO entity)
        {
            Pet pet = mapper.Map<Pet>(entity);
            repository.Remove(pet.Id);
        }

        public void Update(PetDTO entity)
        {
            Pet pet = mapper.Map<Pet>(entity);
            repository.Update(pet);
        }
    }
}
