using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.DTO
{
    public class VetDTO: IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Sallary { get; set; }
    }
}
