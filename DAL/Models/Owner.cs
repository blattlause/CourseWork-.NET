using DAL.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Owner
    {
        private int id;
        private string name;
        private string adress;

        public Owner(int id, string name, string adress) 
        {
            this.id = id;
            this.name = name;
            this.adress = adress;
        }
        public Owner()
        {
            
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Adress { get => adress; set => adress = value; }

        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<Reception> Receptions { get; set; }

    }
}
