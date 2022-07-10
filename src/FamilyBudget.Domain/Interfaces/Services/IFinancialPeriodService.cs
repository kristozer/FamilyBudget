using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Domain.Interfaces.Services
{
    public interface IFinancialPeriodService
    {
        Task<IReadOnlyList<FinancialPeriod>> GetAllAsync();
        Task<IReadOnlyList<FinancialPeriod>> GetSomeAsync(int takeCount);
        Task SaveAsync(FinancialPeriod period);
        Task UpdateAsync(FinancialPeriod period);
        Task<bool> DeleteByIdAsync(int id);
    }
}