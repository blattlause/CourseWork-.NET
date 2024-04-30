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
        private DbSet<Medicine> table = null;


        public MedicineRepository()
        {
            this.DataBase = new ApplicationDBContext();
            table = DataBase.Set<Medicine>();
        }
        public MedicineRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            table = db.Set<Medicine>();
        }

        public void Add(Medicine entity)
        {
            table.Add(entity);
        }

        public void Remove(int id)
        {
            Medicine existing = table.Find(id);
            table.Remove(existing);
        }

        public Medicine GetById(int id)
        {
            return table.Find(id);
        }

        public IList<Medicine> GetAll()
        {
            return table.ToList();
        }

        public void SaveAll(IEnumerable<Medicine> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Medicine entity)
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

