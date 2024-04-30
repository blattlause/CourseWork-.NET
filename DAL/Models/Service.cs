using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Service
    {
        private int id;
        private string title;
        private decimal price;
        public Service(int id, string title, decimal price)
        {
            this.id = id;
            this.title = title;
            this.price = price;
        }
        public Service()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public decimal Price { get => price; set => price = value; }

        public virtual ICollection<ServiceVisit> ServiceVisities { get; set; }
    }
}
