using System;
using System.Collections.Generic;
using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Api.ViewModels
{
    public class FinancialPeriodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PeriodBegin { get; set; }
        public DateTime PeriodEnd { get; set; }
        public decimal Income { get; set; }
        public List<ExpenditureDto> Expenditures { get; set; }
    }
}