using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Intefaces;
using DAL.Models;


namespace BLL.Services.Common
{
    internal class MedicineCardService : IMedicineCardService
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
            return mapper.Map<IList<MedicineCardDTO>>(medicineCards);
        }

        public MedicineCardDTO? GetById(int id)
        {
            MedicineCard? medicineCard = repository.GetById(id);
            return mapper.Map<MedicineCardDTO>(medicineCard);
        }

        public MedicineCardDTO GetMedicineCardForPet(int petId)
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
