﻿using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Intefaces;
using DAL.Models;

namespace BLL.Services.Common
{
    internal class OwnerService: IOwnerService
    {
        private readonly IOwnerRepository repository;
        private readonly IMapper mapper;

        public OwnerService(IOwnerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(OwnerDTO entity)
        {
            Owner owner = mapper.Map<Owner>(entity);
            repository.Add(owner);
            entity.Id = owner.Id;
        }

        public IList<OwnerDTO> GetAll()
        {
            IList<Owner> OwnerDTO = repository.GetAll();
            return mapper.Map<IList<OwnerDTO>>(OwnerDTO);
        }

        public OwnerDTO? GetById(int id)
        {
            Owner? owner = repository.GetById(id);
            return mapper.Map<OwnerDTO>(owner);
        }

        public void Remove(OwnerDTO entity)
        {
            Owner owner = mapper.Map<Owner>(entity);
            repository.Remove(owner.Id);
        }

        public void Update(OwnerDTO entity)
        {
            Owner owner = mapper.Map<Owner>(entity);
            repository.Update(owner);
            entity.Id = owner.Id;
        }
    }
}
