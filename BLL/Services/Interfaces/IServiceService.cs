using BLL.DTO;


namespace BLL.Services.Interfaces
{
    public interface IServiceService : IService<ServiceDTO>
    {
        IEnumerable<ServiceDTO> GetServicesForReception();
    }
}
