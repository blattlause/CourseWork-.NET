using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Pet
    {
        private int id;
        private string name;
        private int age;
        private int idOwner;
        private int idSpecies;
        private double weigth;
        private double heigth;

        public Pet(int id, string name, int age, int idOwner, int idSpicies, double weigth, double heigth)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.idOwner = idOwner;
            this.idSpecies = idSpicies;
            this.weigth = weigth;
            this.heigth = heigth;
        }

        public Pet()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public int IdOwner { get => idOwner; set => idOwner = value; }
        public int IdSpecies { get => idSpecies; set => idSpecies = value; }
        public double Weigth { get => weigth; set => weigth = value; }
        public double Heigth { get => heigth; set => heigth = value; }

        public virtual Owner Owner { get; set; }
        public virtual Species Species { get; set; }
        public virtual ICollection<Visit> Visities { get; set; }
        public virtual MedicineCard MedicineCard { get; set; }
    }
}
