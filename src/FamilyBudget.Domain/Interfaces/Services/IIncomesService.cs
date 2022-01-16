using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Domain.Interfaces.Services;

public interface IIncomesService
{
    Task<IReadOnlyList<Income>> GetAsync(int periodId);
}