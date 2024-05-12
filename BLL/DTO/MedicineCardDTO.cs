using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class MedicineCardDTO: IDTO
    {
        public int Id { get; set; }
        public int IdPet { get; set; }
        public PetDTO Pet { get; set; }
        public ICollection<NoteDTO> Notes { get; set; }
    }
}
