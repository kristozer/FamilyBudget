using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;
using FamilyBudget.Domain.Interfaces.Services;
using FamilyBudget.Domain.Interfaces.DataAccess;

namespace FamilyBudget.Domain.Services
{
    public class FinancialPeriodService : IFinancialPeriodService
    {
        private readonly IRepositoryAsync<FinancialPeriod> _repository;

        public FinancialPeriodService(IRepositoryAsync<FinancialPeriod> finacialPeriodRepository)
        {
            _repository = finacialPeriodRepository;
        }

        public async Task<IReadOnlyList<FinancialPeriod>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task Save(FinancialPeriod period)
        {
            await _repository.AddAsync(period);
        }
    }
}