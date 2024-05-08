using DAL.Intefaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories
{
    internal class NoteRepository: INoteRepository
    {
        private ApplicationDBContext DataBase { get; set; }

        public NoteRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
        }

        public void Add(Note entity)
        {
            DataBase.Note.Add(entity);
            DataBase.SaveChanges();
        }

        public void Remove(int id)
        {
            Note existing = DataBase.Note.Find(id);
            DataBase.Note.Remove(existing);
            DataBase.SaveChanges();
        }

        public Note GetById(int id)
        {
            return DataBase.Note.Find(id);
        }

        public IList<Note> GetAll()
        {
            return DataBase.Note.ToList();
        }

        public void SaveAll(IEnumerable<Note> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Note entity)
        {
            DataBase.Note.Attach(entity);
            DataBase.Entry(entity).State = EntityState.Modified;
            DataBase.SaveChanges();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
