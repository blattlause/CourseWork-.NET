using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Species
    {
        private int id;
        private string title;

        public Species(int id, string title)
        {
            this.id = id;
            this.title = title;
        }
        public Species()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
