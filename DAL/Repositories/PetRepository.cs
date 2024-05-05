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
    public class PetRepository: IPetRepository
    {
        private ApplicationDBContext DataBase { get; set; }

        public PetRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            DataBase.Pet = db.Set<Pet>();
        }

        public void Add(Pet entity)
        {
            DataBase.Pet.Add(entity);
            DataBase.SaveChanges();
        }

        public void Remove(int id)
        {
            Pet existing = DataBase.Pet.Find(id);
            DataBase.Pet.Remove(existing);
            DataBase.SaveChanges();
        }

        public Pet GetById(int id)
        {
            return DataBase.Pet.Find(id);
        }

        public IList<Pet> GetAll()
        {
            return DataBase.Pet.ToList();
        }

        public void SaveAll(IEnumerable<Pet> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Pet entity)
        {
            DataBase.Pet.Attach(entity);
            DataBase.Entry(entity).State = EntityState.Modified;
            DataBase.SaveChanges();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
