using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Visit
    {
        private int id;
        private int idVet;
        private int idPet;

        public Visit(int id, int idVet, int idPet)
        { 
            this.id = id;
            this.idVet = idVet;
            this.idPet = idPet;
        }
        public Visit()
        {
            
        }
        public int Id { get => id; set => id = value; }
        public int IdVet { get => idVet; set => idVet = value; }
        public int IdPet { get => idPet; set => idPet = value; }
        public virtual Pet Pet { get; set; }
        public virtual Vet Vet { get; set; }
        public virtual ICollection<ServiceVisit> ServiceVisities { get; set; }
        
    }
}
