namespace FamilyBudget.Api.ViewModels
{
    public class ExpenditureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int FinancialPeriodId { get; set; }
        public int? PlannedExpenditureId { get; set; }
    }
}