using DAL.Intefaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ServiceVisitRepository: IServiceVisitRepository
    {
        private ApplicationDBContext DataBase { get; set; }
        private DbSet<ServiceVisit> table = null;


        public ServiceVisitRepository()
        {
            this.DataBase = new ApplicationDBContext();
            table = DataBase.Set<ServiceVisit>();
        }
        public ServiceVisitRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            table = db.Set<ServiceVisit>();
        }

        public void Add(ServiceVisit entity)
        {
            table.Add(entity);
        }

        public void Remove(int id)
        {
            ServiceVisit existing = table.Find(id);
            table.Remove(existing);
        }

        public ServiceVisit GetById(int id)
        {
            return table.Find(id);
        }

        public IList<ServiceVisit> GetAll()
        {
            return table.ToList();
        }

        public void SaveAll(IEnumerable<ServiceVisit> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(ServiceVisit entity)
        {
            table.Attach(entity);
            DataBase.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
