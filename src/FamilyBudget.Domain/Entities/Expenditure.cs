namespace FamilyBudget.Domain.Entities
{
    public class Expenditure : BaseEntity
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        
        public int FinancialPeriodId { get; set; }
        public FinancialPeriod FinancialPeriod { get; set; }
        
        public int? PlannedExpenditureId { get; set; }
        public PlannedExpenditure PlannedExpenditure { get; set; }
    }
}