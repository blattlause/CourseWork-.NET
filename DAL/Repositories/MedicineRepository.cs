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
    public class MedicineRepository: IMedicineRepository
    {
        private ApplicationDBContext DataBase { get; set; }

        public MedicineRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            DataBase.Medicine = db.Set<Medicine>();
        }

        public void Add(Medicine entity)
        {
            DataBase.Medicine.Add(entity);
            DataBase.SaveChanges();
        }

        public void Remove(int id)
        {
            Medicine existing = DataBase.Medicine.Find(id);
            DataBase.Medicine.Remove(existing);
            DataBase.SaveChanges();
        }

        public Medicine GetById(int id)
        {
            return DataBase.Medicine.Find(id);
        }

        public IList<Medicine> GetAll()
        {
            return DataBase.Medicine.ToList();
        }

        public void SaveAll(IEnumerable<Medicine> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Medicine entity)
        {
            DataBase.Medicine.Attach(entity);
            DataBase.Entry(entity).State = EntityState.Modified;
            DataBase.SaveChanges();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}

