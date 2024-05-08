using DAL.Intefaces;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories
{
    internal class ClaimRepository: IClaimRepository
    {
        private ApplicationDBContext DataBase { get; set; }

        public ClaimRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
        }

        public void Add(Models.Claim entity)
        {
            DataBase.Claim.Add(entity);
            DataBase.SaveChanges();
        }

        public void Remove(int id)
        {
            Models.Claim existing = DataBase.Claim.Find(id);
            DataBase.Claim.Remove(existing);
            DataBase.SaveChanges();
        }

        public Models.Claim GetById(int id)
        {
            return DataBase.Claim.Find(id);
        }

        public IList<Models.Claim> GetAll()
        {
            return DataBase.Claim.ToList();
        }

        public void SaveAll(IEnumerable<Models.Claim> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.Claim entity)
        {
            DataBase.Claim.Attach(entity);
            DataBase.Entry(entity).State = EntityState.Modified;
            DataBase.SaveChanges();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}

