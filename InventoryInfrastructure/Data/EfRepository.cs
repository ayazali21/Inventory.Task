using System;
using InventoryCore.Entity;
using InventoryCore.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryInfrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(int id) where T : BaseEntity
        {
           
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public T GetById<T>(int id, string include) where T : BaseEntity
        {
            return _dbContext.Set<T>()
                .Include(include)
                .SingleOrDefault(e => e.Id == id);
        }

        public List<T> List<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            

            var query = _dbContext.Set<T>().AsQueryable();
            if (spec != null)
            {
                query = query.Where(spec.Criteria);
            }
            return query.ToList();
        }

        public async Task<T> Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
           await _dbContext.SaveChangesAsync();
        }
    }
}

