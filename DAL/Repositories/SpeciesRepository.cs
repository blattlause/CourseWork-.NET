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
    public class SpeciesRepository: ISpeciesRepository
    {
        private ApplicationDBContext DataBase { get; set; }
        private DbSet<Species> table = null;


        public SpeciesRepository()
        {
            this.DataBase = new ApplicationDBContext();
            table = DataBase.Set<Species>();
        }
        public SpeciesRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            table = db.Set<Species>();
        }

        public void Add(Species entity)
        {
            table.Add(entity);
        }

        public void Remove(int id)
        {
            Species existing = table.Find(id);
            table.Remove(existing);
        }

        public Species GetById(int id)
        {
            return table.Find(id);
        }

        public IList<Species> GetAll()
        {
            return table.ToList();
        }

        public void SaveAll(IEnumerable<Species> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Species entity)
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
