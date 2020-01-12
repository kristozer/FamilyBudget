using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Domain.Interfaces.Services
{
    public interface IFinancialPeriodService
    {
        Task<IReadOnlyList<FinancialPeriod>> GetAll();
        Task Save(FinancialPeriod period);
    }
}