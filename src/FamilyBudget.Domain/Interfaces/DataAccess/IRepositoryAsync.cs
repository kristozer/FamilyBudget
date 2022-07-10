using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Domain.Interfaces.DataAccess
{
    public interface IRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetWithSpecificationAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> DeleteByIdAsync(int id);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}