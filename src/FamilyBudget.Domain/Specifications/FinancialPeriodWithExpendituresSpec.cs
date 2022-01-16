using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Domain.Specifications
{
    public class FinancialPeriodWithExpendituresSpec : BaseSpecification<FinancialPeriod>
    {
        public FinancialPeriodWithExpendituresSpec()
        {
            AddInclude(f => f.Expenditures);
            AddInclude(f => f.Incomes);
        }
    }
}