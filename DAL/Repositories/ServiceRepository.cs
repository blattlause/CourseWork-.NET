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
        
        public ServiceRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
        }

        public void Add(Service entity)
        {
            DataBase.Service.Add(entity);
            DataBase.SaveChanges();
        }

        public void Remove(int id)
        {
            Service existing = DataBase.Service.Find(id);
            DataBase.Service.Remove(existing);
            DataBase.SaveChanges();
        }

        public Service GetById(int id)
        {
            return DataBase.Service.Find(id);
        }

        public IList<Service> GetAll()
        {
            return DataBase.Service.ToList();
        }

        public void SaveAll(IEnumerable<Service> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Service entity)
        {
            DataBase.Service.Attach(entity);
            DataBase.Entry(entity).State = EntityState.Modified;
            DataBase.SaveChanges();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
