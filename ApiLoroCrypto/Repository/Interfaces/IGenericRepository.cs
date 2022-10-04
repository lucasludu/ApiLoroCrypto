using ApiLoroCrypto.Core.Models;

namespace ApiLoroCrypto.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task Insert(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> Delete(T entity);
        void Update(T entity);
    }
}
