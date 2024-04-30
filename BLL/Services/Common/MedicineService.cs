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
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository repository;
        private readonly IMapper mapper;
        public MedicineService(IMedicineRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(MedicineDTO entity)
        {
            Medicine medicine = mapper.Map<Medicine>(entity);
            repository.Add(medicine);
        }

        public IList<MedicineDTO> GetAll()
        {
            IList<Medicine> medicines = repository.GetAll();
            return medicines.Select(c => mapper.Map<MedicineDTO>(c)).ToList();
        }

        public MedicineDTO? GetById(int id)
        {
            Medicine? medicine = repository.GetById(id);
            return mapper.Map<MedicineDTO>(medicine);
        }

        public void Remove(MedicineDTO entity)
        {
            Medicine medicine = mapper.Map<Medicine>(entity);
            repository.Remove(medicine.Id);
        }

        public void Update(MedicineDTO entity)
        {
            Medicine medicine = mapper.Map<Medicine>(entity);
            repository.Update(medicine);
        }
    }
}
