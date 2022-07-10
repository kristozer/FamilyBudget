using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;
using FamilyBudget.Domain.Interfaces.DataAccess;
using FamilyBudget.Domain.Interfaces.Services;
using FamilyBudget.Domain.Specifications;

namespace FamilyBudget.Domain.Services;

public class ExpendituresService : IExpendituresService
{
    private readonly IRepositoryAsync<Expenditure> _repository;

    public ExpendituresService(IRepositoryAsync<Expenditure> repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<Expenditure>> GetAsync(int periodId)
    {
        return _repository.GetWithSpecificationAsync(new ExpendituresByPeriodIdSpec(periodId));
    }

    public Task SaveAsync(Expenditure expenditure)
    {
        return _repository.AddAsync(expenditure);
    }

    public Task UpdateAsync(Expenditure expenditure)
    {
        return _repository.UpdateAsync(expenditure);
    }

    public Task<bool> DeleteByIdAsync(int id)
    {
        return _repository.DeleteByIdAsync(id);
    }
}