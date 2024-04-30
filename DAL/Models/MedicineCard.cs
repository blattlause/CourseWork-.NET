using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MedicineCard
    {
        private int id;
        private int idPet;


        public MedicineCard(int id, int idPet)
        {
            this.id = id;
            this.idPet = idPet;
        }
        public MedicineCard()
        {
            
        }
        public int Id { get => id; set => id = value; }
        public int IdPet { get => idPet; set => idPet = value; }
        public virtual Pet Pet { get; set; }
        public virtual ICollection<Note> Notes { get; set; }

    }

}
