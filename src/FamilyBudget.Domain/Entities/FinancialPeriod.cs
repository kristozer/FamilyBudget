using System;

namespace FamilyBudget.Domain.Entities
{
    public class FinancialPeriod : BaseEntity
    {
        public string Name { get; private set; }
        public DateTime PeriodBegin { get; private set; }
        public DateTime PeriodEnd { get; private set; }
        
        public decimal Income { get; set; }


        protected FinancialPeriod(){}

        public FinancialPeriod(string name, DateTime periodBegin, DateTime periodEnd, decimal income)
        {
            Name = name;
            PeriodBegin = periodBegin;
            PeriodEnd = periodEnd;
            Income = income;
        }
    }
}