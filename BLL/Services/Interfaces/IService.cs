using BLL.DTO;


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
