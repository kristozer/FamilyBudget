using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;
using FamilyBudget.Domain.Interfaces.Services;
using FamilyBudget.Domain.Interfaces.DataAccess;
using FamilyBudget.Domain.Specifications;

namespace FamilyBudget.Domain.Services
{
    public class FinancialPeriodService : IFinancialPeriodService
    {
        private readonly IRepositoryAsync<FinancialPeriod> _repository;

        public FinancialPeriodService(IRepositoryAsync<FinancialPeriod> finacialPeriodRepository)
        {
            _repository = finacialPeriodRepository;
        }

        public Task<IReadOnlyList<FinancialPeriod>> GetAllAsync()
        {
            return _repository.GetWithSpecificationAsync(new PeriodsWithInculdesSpec());
        }

        public Task<IReadOnlyList<FinancialPeriod>> GetSomeAsync(int takeCount)
        {
            return _repository.GetWithSpecificationAsync(new TakeActualPeriodsSpec(takeCount));
        }

        public async Task SaveAsync(FinancialPeriod period)
        {
            await _repository.AddAsync(period);
        }
        public async Task UpdateAsync(FinancialPeriod period)
        {
            await _repository.AddAsync(period);
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            return _repository.DeleteByIdAsync(id);
        }
    }
}