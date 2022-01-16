using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Domain.Specifications;

public class IncomesByPeriodIdSpec : BaseSpecification<Income>
{
    public IncomesByPeriodIdSpec(int periodId) : base(income => income.FinancialPeriodId == periodId)
    {
    }
}