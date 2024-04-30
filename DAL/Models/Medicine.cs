using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Medicine
    {
        private int id;
        private string title;
        private string description;
        private decimal price;
        public Medicine(int id, string title, string description, decimal price)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.price = price;
        }
        public Medicine()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public decimal Price { get => price; set => price = value; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
