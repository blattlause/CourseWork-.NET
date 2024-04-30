using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class VisitDTO: IDTO
    {
        public int Id { get; set; }
        public int IdVet { get; set; }
        public int IdPet { get; set; }
    }
}
