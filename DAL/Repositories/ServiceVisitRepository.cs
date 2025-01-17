﻿using DAL.Intefaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories
{
    internal class ServiceVisitRepository: IServiceVisitRepository
    {
        private ApplicationDBContext DataBase { get; set; }

        public ServiceVisitRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
        }

        public void Add(ServiceVisit entity)
        {
            DataBase.ServiceVisit.Add(entity);
            DataBase.SaveChanges();
        }

        public void Remove(int id)
        {
            ServiceVisit existing = DataBase.ServiceVisit.Find(id);
            DataBase.ServiceVisit.Remove(existing);
            DataBase.SaveChanges();
        }

        public ServiceVisit GetById(int id)
        {
            return DataBase.ServiceVisit.Find(id);
        }

        public IList<ServiceVisit> GetAll()
        {
            return DataBase.ServiceVisit.ToList();
        }

        public void SaveAll(IEnumerable<ServiceVisit> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(ServiceVisit entity)
        {
            DataBase.ServiceVisit.Attach(entity);
            DataBase.Entry(entity).State = EntityState.Modified;
            DataBase.SaveChanges();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
