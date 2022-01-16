using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;
using FamilyBudget.Domain.Interfaces.DataAccess;
using FamilyBudget.Domain.Interfaces.Services;
using FamilyBudget.Domain.Specifications;

namespace FamilyBudget.Domain.Services;

public class IncomesService : IIncomesService
{
    private readonly IRepositoryAsync<Income> _repository;

    public IncomesService(IRepositoryAsync<Income> repository)
    {
        _repository = repository;
    }


    public Task<IReadOnlyList<Income>> GetAsync(int periodId)
    {
        return _repository.GetWithSpecificationAsync(new IncomesByPeriodIdSpec(periodId));
    }
}