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
    public class OwnerRepository: IOwnerRepository
    {
        private ApplicationDBContext DataBase { get; set; }
        private DbSet<Owner> table = null;


        public OwnerRepository()
        {
            this.DataBase = new ApplicationDBContext();
            table = DataBase.Set<Owner>();
        }
        public OwnerRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            table = db.Set<Owner>();
        }

        public void Add(Owner entity)
        {
            table.Add(entity);
        }

        public void Remove(int id)
        {
            Owner existing = table.Find(id);
            table.Remove(existing);
        }

        public Owner GetById(int id)
        {
            return table.Find(id);
        }

        public IList<Owner> GetAll()
        {
            return table.ToList();
        }

        public void SaveAll(IEnumerable<Owner> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Owner entity)
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
