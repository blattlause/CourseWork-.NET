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
    public class ServiceRepository: IServiceRepository
    {
        private ApplicationDBContext DataBase { get; set; }
        private DbSet<Service> table = null;


        public ServiceRepository()
        {
            this.DataBase = new ApplicationDBContext();
            table = DataBase.Set<Service>();
        }
        public ServiceRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            table = db.Set<Service>();
        }

        public void Add(Service entity)
        {
            table.Add(entity);
        }

        public void Remove(int id)
        {
            Service existing = table.Find(id);
            table.Remove(existing);
        }

        public Service GetById(int id)
        {
            return table.Find(id);
        }

        public IList<Service> GetAll()
        {
            return table.ToList();
        }

        public void SaveAll(IEnumerable<Service> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Service entity)
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
