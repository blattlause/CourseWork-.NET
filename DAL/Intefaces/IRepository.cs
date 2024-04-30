using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Intefaces
{
    public interface IRepository<T>
    {
        void Add(T t);
        void Remove(int id);
        T? GetById(int id);
        IList<T> GetAll();
        void Update(T t);
    }
}
