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
    public class VisitRepository: IVisitRepository
    {
        private ApplicationDBContext DataBase { get; set; }

        public VisitRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            DataBase.Visit = db.Set<Visit>();
        }

        public void Add(Visit entity)
        {
            DataBase.Visit.Add(entity);
            DataBase.SaveChanges();
        }

        public void Remove(int id)
        {
            Visit existing = DataBase.Visit.Find(id);
            DataBase.Visit.Remove(existing);
            DataBase.SaveChanges();
        }

        public Visit GetById(int id)
        {
            return DataBase.Visit.Find(id);
        }

        public IList<Visit> GetAll()
        {
            return DataBase.Visit.ToList();
        }

        public void SaveAll(IEnumerable<Visit> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Visit entity)
        {
            DataBase.Visit.Attach(entity);
            DataBase.Entry(entity).State = EntityState.Modified;
            DataBase.SaveChanges();
        }
        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
