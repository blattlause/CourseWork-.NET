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
    public class MedicineCardService : IMedicineCardService
    {
        private readonly IMedicineCardRepository repository;
        private readonly IMapper mapper;
        public MedicineCardService(IMedicineCardRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(MedicineCardDTO entity)
        {
            MedicineCard medicineCard = mapper.Map<MedicineCard>(entity);
            repository.Add(medicineCard);
        }

        public IList<MedicineCardDTO> GetAll()
        {
            IList<MedicineCard> medicineCards = repository.GetAll();
            return medicineCards.Select(c => mapper.Map<MedicineCardDTO>(c)).ToList();
        }

        public MedicineCardDTO? GetById(int id)
        {
            MedicineCard? medicineCard = repository.GetById(id);
            return mapper.Map<MedicineCardDTO>(medicineCard);
        }

        public IEnumerable<MedicineCardDTO> GetMedicineCardForPet(int petId)
        {
            throw new NotImplementedException();
        }

        public void Remove(MedicineCardDTO entity)
        {
            MedicineCard medicineCard = mapper.Map<MedicineCard>(entity);
            repository.Remove(medicineCard.Id);
        }

        public void Update(MedicineCardDTO entity)
        {
            MedicineCard medicineCard = mapper.Map<MedicineCard>(entity);
            repository.Update(medicineCard);
        }
    }
}
