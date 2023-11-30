using Microsoft.EntityFrameworkCore;
using Prototipos.BAL.Interfaces;
using Prototipos.DAL.Models;

namespace Prototipos.BAL.Repositorios
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly PrototiposContext dbContext;

        protected BaseRepository(PrototiposContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public virtual async Task<T> AddAsync<T>(T entity) where T : BaseModel
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }


        public async Task<int> DeleteAsync<T>(T entity) where T : BaseModel
        {
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<T>> ListAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }


        public async Task<int> UpdateAsync<T>(T entity) where T : BaseModel
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            return await dbContext.SaveChangesAsync();
        }
    }
}