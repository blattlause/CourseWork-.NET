using BLL.DTO;


namespace BLL.Services.Interfaces
{
    public interface IReceptionService : IService<ReceptionDTO>
    {
        IEnumerable<ReceptionDTO> GetByDate(DateTime date);
        IEnumerable<ReceptionDTO> GetByVet(int idVet);
        IEnumerable<ReceptionDTO> GetByOwner(int idOwner);
    }
}
