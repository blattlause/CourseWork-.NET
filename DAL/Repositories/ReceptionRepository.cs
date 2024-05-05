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

        public ReceptionRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            DataBase.Reception = db.Set<Reception>();
        }

        public void Add(Reception entity)
        {
            DataBase.Reception.Add(entity);
            DataBase.SaveChanges();
        }

        public void Remove(int id)
        {
            Reception existing = DataBase.Reception.Find(id);
            DataBase.Reception.Remove(existing);
            DataBase.SaveChanges();
        }

        public Reception GetById(int id)
        {
            return DataBase.Reception.Find(id);
        }

        public IList<Reception> GetAll()
        {
            return DataBase.Reception.ToList();
        }

        public void SaveAll(IEnumerable<Reception> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Reception entity)
        {
            DataBase.Reception.Attach(entity);
            DataBase.Entry(entity).State = EntityState.Modified;
            DataBase.SaveChanges();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
