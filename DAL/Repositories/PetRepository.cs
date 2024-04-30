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
        private DbSet<Pet> table = null;


        public PetRepository()
        {
            this.DataBase = new ApplicationDBContext();
            table = DataBase.Set<Pet>();
        }
        public PetRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            table = db.Set<Pet>();
        }

        public void Add(Pet entity)
        {
            table.Add(entity);
        }

        public void Remove(int id)
        {
            Pet existing = table.Find(id);
            table.Remove(existing);
        }

        public Pet GetById(int id)
        {
            return table.Find(id);
        }

        public IList<Pet> GetAll()
        {
            return table.ToList();
        }

        public void SaveAll(IEnumerable<Pet> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Pet entity)
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
