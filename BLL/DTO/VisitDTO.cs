using DAL.Models;
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

        public  Pet Pet { get; set; }
        public  Vet Vet { get; set; }
        public  ICollection<ServiceVisit> ServiceVisities { get; set; }
        public  ICollection<Note> Notes { get; set; }
    }
}
