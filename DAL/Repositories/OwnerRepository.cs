using DAL.Intefaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories
{
    internal class OwnerRepository: IOwnerRepository
    {
        private ApplicationDBContext DataBase { get; set; }

        public OwnerRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
        }

        public void Add(Owner entity)
        {
            DataBase.Owner.Add(entity);
            DataBase.SaveChanges();
        }

        public void Remove(int id)
        {
            Owner existing = DataBase.Owner.Find(id);
            DataBase.Owner.Remove(existing);
            DataBase.SaveChanges();
        }

        public Owner GetById(int id)
        {
            return DataBase.Owner.Find(id);
        }

        public IList<Owner> GetAll()
        {
            return DataBase.Owner.ToList();
        }

        public void SaveAll(IEnumerable<Owner> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Owner entity)
        {
            DataBase.Owner.Attach(entity);
            DataBase.Entry(entity).State = EntityState.Modified;
            DataBase.SaveChanges();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
