using DAL.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Owner
    {
        private int id;
        private string name;
        private string? adress;
        private string? idUser;

        public Owner(int id, string name, string adress, string idUser) 
        {
            this.id = id;
            this.name = name;
            this.adress = adress;
            this.idUser = idUser;
        }
        public Owner()
        {
            
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string? Adress { get => adress; set => adress = value; }
        public string? IdUser { get => idUser; set => idUser = value; }

        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<Reception> Receptions { get; set; }

    }
}
