using System;
using System.Collections.Generic;

namespace FamilyBudget.Domain.Entities
{
    public class FinancialPeriod : BaseEntity
    {
        public string Name { get; set; }
        public DateTime PeriodBegin { get; set; }
        public DateTime PeriodEnd { get; set; }
        public decimal Income { get; set; }
        public List<Expenditure> Expenditures { get; set; }
    }
}