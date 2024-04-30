using DAL.Intefaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ClaimRepository: IClaimRepository
    {
        private ApplicationDBContext DataBase { get; set; }
        private DbSet<Models.Claim> table = null;


        public ClaimRepository()
        {
            this.DataBase = new ApplicationDBContext();
            table = DataBase.Set<Models.Claim>();
        }
        public ClaimRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            table = db.Set<Models.Claim>();
        }

        public void Add(Models.Claim entity)
        {
            table.Add(entity);
        }

        public void Remove(int id)
        {
            Models.Claim existing = table.Find(id);
            table.Remove(existing);
        }

        public Models.Claim GetById(int id)
        {
            return table.Find(id);
        }

        public IList<Models.Claim> GetAll()
        {
            return table.ToList();
        }

        public void SaveAll(IEnumerable<Models.Claim> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.Claim entity)
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

