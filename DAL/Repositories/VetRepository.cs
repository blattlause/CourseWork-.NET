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
    public class VetRepository: IVetRepository
    {
        private ApplicationDBContext DataBase { get; set; }
        private DbSet<Vet> table = null;

        public VetRepository()
        {
            this.DataBase = new ApplicationDBContext();
            table = DataBase.Set<Vet>();
        }
        public VetRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            table = db.Set<Vet>();
        }

        public void Add(Vet entity)
        {
            table.Add(entity);
        }

        public void Remove(int id)
        {
            Vet existing = table.Find(id);
            table.Remove(existing);
        }

        public Vet GetById(int id)
        {
            return table.Find(id);
        }

        public IList<Vet> GetAll()
        {
            return table.ToList();
        }

        public void SaveAll(IEnumerable<Vet> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Vet entity)
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
