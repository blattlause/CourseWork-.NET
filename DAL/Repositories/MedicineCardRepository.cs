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

        public MedicineCardRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            DataBase.MedicineCard = db.Set<MedicineCard>();
        }

        public void Add(MedicineCard entity)
        {
            DataBase.MedicineCard.Add(entity);
            DataBase.SaveChanges();
        }

        public void Remove(int id)
        {
            MedicineCard existing = DataBase.MedicineCard.Find(id);
            DataBase.MedicineCard.Remove(existing);
            DataBase.SaveChanges();
        }

        public MedicineCard GetById(int id)
        {
            return DataBase.MedicineCard.Find(id);
        }

        public IList<MedicineCard> GetAll()
        {
            return DataBase.MedicineCard.ToList();
        }

        public void SaveAll(IEnumerable<MedicineCard> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(MedicineCard entity)
        {
            DataBase.MedicineCard.Attach(entity);
            DataBase.Entry(entity).State = EntityState.Modified;
            DataBase.SaveChanges();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
