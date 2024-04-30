using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IService<T> where T : IDTO
    {
        T? GetById(int id);

        void Update(T entity);

        void Remove(T entity);

        void Add(T entity);
        IList<T> GetAll();
    }
}
