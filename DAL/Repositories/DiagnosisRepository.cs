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
    public class DiagnosisRepository: IDiagnosisRepository
    {
        private ApplicationDBContext DataBase { get; set; }
        private DbSet<Diagnosis> table = null;


        public DiagnosisRepository()
        {
            this.DataBase = new ApplicationDBContext();
            table = DataBase.Set<Diagnosis>();
        }
        public DiagnosisRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            table = db.Set<Diagnosis>();
        }

        public void Add(Diagnosis entity)
        {
            table.Add(entity);
        }

        public void Remove(int id)
        {
            Diagnosis existing = table.Find(id);
            table.Remove(existing);
        }

        public Diagnosis GetById(int id)
        {
            return table.Find(id);
        }

        public IList<Diagnosis> GetAll()
        {
            return table.ToList();
        }

        public void SaveAll(IEnumerable<Diagnosis> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Diagnosis entity)
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
