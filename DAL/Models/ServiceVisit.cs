using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ServiceVisit
    {
        private int id;
        private int idService;
        private int idVisit;

        public ServiceVisit(int id, int idService, int idVisitint)
        { 
            this.id = id;
            this.idService = idService;
            this.idVisit = idVisitint;
        }
        public ServiceVisit()
        {
            
        }
        public int Id { get => id; set => id = value; }
        public int IdService { get => idService; set => idService = value; }
        public int IdVisit { get => idVisit; set => idVisit = value; }
        public virtual Visit Visit { get; set; }
        public virtual Service Service { get; set; }
    }
}
