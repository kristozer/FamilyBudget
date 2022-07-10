using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Domain.Interfaces.Services;

public interface IExpendituresService
{
    Task<IReadOnlyList<Expenditure>> GetAsync(int periodId);
    Task SaveAsync(Expenditure expenditure);
    Task UpdateAsync(Expenditure expenditure);
    Task<bool> DeleteByIdAsync(int id);
}