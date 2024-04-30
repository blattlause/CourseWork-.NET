using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.DTO
{
    public class PetDTO : IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int IdOwner { get; set; }
        public int IdSpecies { get; set; }
        public double Weigth { get; set; }
        public double Heigth { get; set; }
    }
}
