using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Claim
    {
        private int id;
        private string title;
        private string description;

        public Claim(int id, string title, string description)
        {
            this.id = id;
            this.title = title;
            this.description = description;
        }
        public Claim()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
