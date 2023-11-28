using Microsoft.EntityFrameworkCore;
using Prototipos.BAL.Interfaces;
using Prototipos.DAL.Models;

namespace Prototipos.BAL.Repositorios
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly PrototiposContext _dbContext;

        protected BaseRepository(PrototiposContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync<T>(T entity) where T : BaseModel
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }


        public async Task<int> DeleteAsync<T>(T entity) where T : BaseModel
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<T>> ListAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }


        public async Task<int> UpdateAsync<T>(T entity) where T : BaseModel
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }
}