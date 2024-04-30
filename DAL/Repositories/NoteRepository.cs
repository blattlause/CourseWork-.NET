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
    public class NoteRepository: INoteRepository
    {
        private ApplicationDBContext DataBase { get; set; }
        private DbSet<Note> table = null;


        public NoteRepository()
        {
            this.DataBase = new ApplicationDBContext();
            table = DataBase.Set<Note>();
        }
        public NoteRepository(ApplicationDBContext db)
        {
            this.DataBase = db;
            table = db.Set<Note>();
        }

        public void Add(Note entity)
        {
            table.Add(entity);
        }

        public void Remove(int id)
        {
            Note existing = table.Find(id);
            table.Remove(existing);
        }

        public Note GetById(int id)
        {
            return table.Find(id);
        }

        public IList<Note> GetAll()
        {
            return table.ToList();
        }

        public void SaveAll(IEnumerable<Note> updatalist)
        {
            throw new NotImplementedException();
        }

        public void Update(Note entity)
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
