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

        public DiagnosisRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            DataBase.Diagnosis = db.Set<Diagnosis>();
        }

        public void Add(Diagnosis entity)
        {
            DataBase.Diagnosis.Add(entity);
            DataBase.SaveChanges();
        }

        public void Remove(int id)
        {
            Diagnosis existing = DataBase.Diagnosis.Find(id);
            DataBase.Diagnosis.Remove(existing);
            DataBase.SaveChanges();
        }

        public Diagnosis GetById(int id)
        {
            return DataBase.Diagnosis.Find(id);
        }

        public IList<Diagnosis> GetAll()
        {
            return DataBase.Diagnosis.ToList();
        }

        public void SaveAll(IEnumerable<Diagnosis> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Diagnosis entity)
        {
            DataBase.Diagnosis.Attach(entity);
            DataBase.Entry(entity).State = EntityState.Modified;
            DataBase.SaveChanges();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
