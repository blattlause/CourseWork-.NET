using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IReceptionService : IService<ReceptionDTO>
    {
        IEnumerable<ReceptionDTO> GetByDate(DateTime date);
        IEnumerable<ReceptionDTO> GetByVet(int idVet);
        IEnumerable<ReceptionDTO> GetByOwner(int idOwner);
    }
}
