using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Vet
    {
        private int id;
        private string name;
        private decimal? sallary;
        private string? idUser;

        public Vet(int id, string name, decimal sallary, string idUser) 
        {
            this.id = id;
            this.name = name;
            this.sallary = sallary;
            this.idUser = idUser;
        }

        public Vet()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal? Sallary { get => sallary; set => sallary = value; }
        public string? IdUser { get => idUser; set => idUser = value; }

        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Visit> Visities { get; set; }
        public virtual ICollection<Reception> Receptions { get; set; }

    }
}
