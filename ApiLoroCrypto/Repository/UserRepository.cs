using ApiLoroCrypto.Core.Models;
using ApiLoroCrypto.DataAccess;
using ApiLoroCrypto.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiLoroCrypto.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        #region ExistUser
        public async Task<bool> ExistUser(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
        #endregion

        #region GetByEmail
        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        #endregion

    }
}
