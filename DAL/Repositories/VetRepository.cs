using DAL.Intefaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories
{
    internal class VetRepository: IVetRepository
    {
        private ApplicationDBContext DataBase { get; set; }

        public VetRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
        }

        public void Add(Vet entity)
        {
            DataBase.Vet.Add(entity);
            DataBase.SaveChanges();
        }

        public void Remove(int id)
        {
            Vet existing = DataBase.Vet.Find(id);
            DataBase.Vet.Remove(existing);
            DataBase.SaveChanges();
        }

        public Vet GetById(int id)
        {
            return DataBase.Vet.Find(id);
        }

        public IList<Vet> GetAll()
        {
            return DataBase.Vet.ToList();
        }

        public void SaveAll(IEnumerable<Vet> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Vet entity)
        {
            DataBase.Vet.Attach(entity);
            DataBase.Entry(entity).State = EntityState.Modified;
            DataBase.SaveChanges();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
