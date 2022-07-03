using System;
using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Domain.Specifications
{
    public sealed class TakeActualPeriodsSpec : PeriodsWithInculdesSpec
    {
        public TakeActualPeriodsSpec(int takeCount): base(f => f.PeriodEnd > DateTime.Now)
        {
            if(takeCount > 0)
            {
                ApplyPaging(0, takeCount);
            }

            ApplyOrderBy(s => s.PeriodBegin);
        }
    }
}