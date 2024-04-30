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
    public class MedicineCardRepository: IMedicineCardRepository
    {
        private ApplicationDBContext DataBase { get; set; }
        private DbSet<MedicineCard> table = null;


        public MedicineCardRepository()
        {
            this.DataBase = new ApplicationDBContext();
            table = DataBase.Set<MedicineCard>();
        }
        public MedicineCardRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            table = db.Set<MedicineCard>();
        }

        public void Add(MedicineCard entity)
        {
            table.Add(entity);
        }

        public void Remove(int id)
        {
            MedicineCard existing = table.Find(id);
            table.Remove(existing);
        }

        public MedicineCard GetById(int id)
        {
            return table.Find(id);
        }

        public IList<MedicineCard> GetAll()
        {
            return table.ToList();
        }

        public void SaveAll(IEnumerable<MedicineCard> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(MedicineCard entity)
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
