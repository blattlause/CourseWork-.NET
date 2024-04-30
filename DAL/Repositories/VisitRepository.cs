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
        private DbSet<Visit> table = null;

        public VisitRepository()
        {
            this.DataBase = new ApplicationDBContext();
            table = DataBase.Set<Visit>();
        }
        public VisitRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            table = db.Set<Visit>();
        }

        public void Add(Visit entity)
        {
            table.Add(entity);
        }

        public void Remove(int id)
        {
            Visit existing = table.Find(id);
            table.Remove(existing);
        }

        public Visit GetById(int id)
        {
            return table.Find(id);
        }

        public IList<Visit> GetAll()
        {
            return table.ToList();
        }

        public void SaveAll(IEnumerable<Visit> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Visit entity)
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
