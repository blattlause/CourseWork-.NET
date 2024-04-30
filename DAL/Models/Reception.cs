using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Reception
    {
        private int id;
        private DateTime date;
        private int idVet;
        private int idOwner;

        public Reception(int id, DateTime date, int idVet, int idOwner)
        { 
            this.id = id;
            this.date = date;
            this.idVet = idVet;
            this.idOwner = idOwner;
        }
        public Reception()
        {
            
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public int IdVet { get => idVet; set => idVet = value; }
        public int IdOwner { get => idOwner; set => idOwner = value; }

        public virtual Owner Owner { get; set; }
        public virtual Vet Vet { get; set; }
    }
}
