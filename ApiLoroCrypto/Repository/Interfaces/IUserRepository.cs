using ApiLoroCrypto.Core.Models;

namespace ApiLoroCrypto.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<bool> ExistUser(string email);
    }
}
