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
        
        public SpeciesRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
        }

        public void Add(Species entity)
        {
            DataBase.Species.Add(entity);
            DataBase.SaveChanges();
        }

        public void Remove(int id)
        {
            Species existing = DataBase.Species.Find(id);
            DataBase.Species.Remove(existing);
            DataBase.SaveChanges();
        }

        public Species GetById(int id)
        {
            return DataBase.Species.Find(id);
        }

        public IList<Species> GetAll()
        {
            return DataBase.Species.ToList();
        }

        public void SaveAll(IEnumerable<Species> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Species entity)
        {
            DataBase.Species.Update(entity);
            DataBase.SaveChanges();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
