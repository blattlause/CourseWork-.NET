using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Diagnosis
    {
        private int id;
        private string title;

        public Diagnosis(int id, string title)
        {
            this.id = id;
            this.title = title;
        }
        public Diagnosis()
        {
            
        }

        public int Id { get => id ; set => id = value;  }
        public string Title { get => title; set => title = value; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
