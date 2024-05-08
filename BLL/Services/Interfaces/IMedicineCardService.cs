using BLL.DTO;


namespace BLL.Services.Interfaces
{
    public interface IMedicineCardService : IService<MedicineCardDTO>
    {
        MedicineCardDTO GetMedicineCardForPet(int petId);
    }
}
