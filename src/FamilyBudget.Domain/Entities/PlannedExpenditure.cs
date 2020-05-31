using System;

namespace FamilyBudget.Domain.Entities
{
    public class PlannedExpenditure : BaseEntity
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime Period { get; set; }
        public Expenditure Expenditure { get; set; }
    }
}