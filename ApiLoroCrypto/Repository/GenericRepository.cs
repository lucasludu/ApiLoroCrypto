using ApiLoroCrypto.Core.Models;
using ApiLoroCrypto.DataAccess;
using ApiLoroCrypto.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiLoroCrypto.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Delete
        public async Task<bool> Delete(T entity)
        {
            var existing = await this.GetById(entity.Id);
            if(existing == null)
            {
                return false;
            }
            existing.IsDeleted = true;
            this.Update(existing);
            return true;
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        #endregion

        #region GetById
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
        }
        #endregion

        #region Insert
        public async Task Insert(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        #endregion

        #region Update
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        #endregion


    }
}
