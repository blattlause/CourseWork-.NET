using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.DTO
{
    public class ReceptionDTO : IDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int IdVet { get; set; }
        public int IdOwner { get; set; }
    }
}
