using System;

namespace FamilyBudget.Domain.Entities
{
    public class FinancialPeriod : BaseEntity
    {
        public string Name { get; private set; }
        public DateTime PeriodBegin { get; private set; }
        public DateTime PeriodEnd { get; private set; }


        protected FinancialPeriod(){}

        public FinancialPeriod(string name, DateTime periodBegin, DateTime periodEnd)
        {
            Name = name;
            PeriodBegin = periodBegin;
            PeriodEnd = periodEnd;
        }
    }
}