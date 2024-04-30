using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface INoteService : IService<NoteDTO>
    {
        IEnumerable<NoteDTO> GetByMedicineCardId(int medicineCardId);
        IEnumerable<NoteDTO> GetByVetId(int vetId);
    }
}
