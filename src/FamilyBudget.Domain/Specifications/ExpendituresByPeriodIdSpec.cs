using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Domain.Specifications;

public class ExpendituresByPeriodIdSpec : BaseSpecification<Expenditure>
{
    public ExpendituresByPeriodIdSpec(int periodId) : base(expenditure => expenditure.FinancialPeriodId == periodId)
    {
    }
}