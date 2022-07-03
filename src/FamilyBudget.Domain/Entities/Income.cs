using System.Text.Json.Serialization;

namespace FamilyBudget.Domain.Entities
{
    public class Income : BaseEntity
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public int FinancialPeriodId { get; set; }
        [JsonIgnore]
        public FinancialPeriod FinancialPeriod { get; set; }
    }
}