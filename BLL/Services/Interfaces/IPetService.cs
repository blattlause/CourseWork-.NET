using BLL.DTO;


namespace BLL.Services.Interfaces
{
    public interface IPetService : IService<PetDTO>
    {
        IEnumerable<PetDTO> GetPetsByOwner();
    }
}
