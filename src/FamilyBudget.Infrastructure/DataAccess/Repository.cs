using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;
using FamilyBudget.Domain.Interfaces;
using FamilyBudget.Domain.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FamilyBudget.Infrastructure.DataAccess
{
    public class Repository<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        
        public Repository(DbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);
        public async Task<T> GetByIdAsync(int id, ISpecification<T> spec)
        { 
            return await ApplySpecification(spec)
                .FirstOrDefaultAsync(i=>i.Id == id);
        }
        public async Task<IReadOnlyList<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();
        public async Task<IReadOnlyList<T>> GetFilteredAsync(ISpecification<T> spec) => await ApplySpecification(spec).ToListAsync();
        public async Task<int> CountAsync(ISpecification<T> spec) => await ApplySpecification(spec).CountAsync();
        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationExecutor<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}