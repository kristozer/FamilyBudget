using System.Text.Json.Serialization;

namespace FamilyBudget.Domain.Entities
{
    public class Expenditure : BaseEntity
    {
        public string Name { get; set; }
        public decimal PlannedToSpendValue { get; set; }
        public decimal SpendValue { get; set; }
        
        public int FinancialPeriodId { get; set; }
        [JsonIgnore]
        public FinancialPeriod FinancialPeriod { get; set; }
        
        public int? PlannedExpenditureId { get; set; }
        [JsonIgnore]
        public PlannedExpenditure PlannedExpenditure { get; set; }
    }
}