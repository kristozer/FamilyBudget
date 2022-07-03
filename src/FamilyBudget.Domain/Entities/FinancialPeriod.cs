using System;
using System.Collections.Generic;

namespace FamilyBudget.Domain.Entities
{
    public class FinancialPeriod : BaseEntity
    {
        public DateTime PeriodBegin { get; set; }
        public DateTime PeriodEnd { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Expenditure> Expenditures { get; set; }
    }
}