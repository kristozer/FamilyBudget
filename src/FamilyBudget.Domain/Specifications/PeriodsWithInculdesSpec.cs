using System;
using System.Linq.Expressions;
using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Domain.Specifications
{
    public class PeriodsWithInculdesSpec : BaseSpecification<FinancialPeriod>
    {
        public PeriodsWithInculdesSpec()
        {
            AddIncludes();
        }

        protected PeriodsWithInculdesSpec(Expression<Func<FinancialPeriod, bool>> criteria): base(criteria)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInclude(f => f.Expenditures);
            AddInclude(f => f.Incomes);
        }
    }
}