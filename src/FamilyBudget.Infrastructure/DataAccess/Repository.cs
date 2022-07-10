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
        private readonly AppDbContext _appDbContext;
        
        public Repository(AppDbContext dbcontext)
        {
            _appDbContext = dbcontext;
        }
        public async Task<T> GetByIdAsync(int id) => await _appDbContext.Set<T>().FindAsync(id);
        public async Task<T> GetByIdAsync(int id, ISpecification<T> spec)
        { 
            return await ApplySpecification(spec)
                .FirstOrDefaultAsync(i=>i.Id == id);
        }
        public async Task<IReadOnlyList<T>> GetAllAsync() => await _appDbContext.Set<T>().ToListAsync();
        public async Task<IReadOnlyList<T>> GetWithSpecificationAsync(ISpecification<T> spec) => await ApplySpecification(spec).ToListAsync();
        public async Task<int> CountAsync(ISpecification<T> spec) => await ApplySpecification(spec).CountAsync();
        public async Task<T> AddAsync(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await _appDbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity is null)
            {
                return false;
            }

            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationExecutor<T>.GetQuery(_appDbContext.Set<T>().AsQueryable(), spec);
        }
    }
}