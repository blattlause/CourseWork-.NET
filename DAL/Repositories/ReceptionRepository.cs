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
    public class ReceptionRepository: IReceptionRepository
    {
        private ApplicationDBContext DataBase { get; set; }
        private DbSet<Reception> table = null;


        public ReceptionRepository()
        {
            this.DataBase = new ApplicationDBContext();
            table = DataBase.Set<Reception>();
        }
        public ReceptionRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            table = db.Set<Reception>();
        }

        public void Add(Reception entity)
        {
            table.Add(entity);
        }

        public void Remove(int id)
        {
            Reception existing = table.Find(id);
            table.Remove(existing);
        }

        public Reception GetById(int id)
        {
            return table.Find(id);
        }

        public IList<Reception> GetAll()
        {
            return table.ToList();
        }

        public void SaveAll(IEnumerable<Reception> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Reception entity)
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
