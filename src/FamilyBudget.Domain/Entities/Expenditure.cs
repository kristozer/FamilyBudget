namespace FamilyBudget.Domain.Entities
{
    public class Expenditure : BaseEntity
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int FinancialPeriodId { get; set; }
    }
}