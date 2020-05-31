using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Domain.Specifications
{
    public class FinancialPeriodWithExpendituresSpecification : BaseSpecification<FinancialPeriod>
    {
        public FinancialPeriodWithExpendituresSpecification()
        {
            AddInclude(f => f.Expenditures);
        }
    }
}