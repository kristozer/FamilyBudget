using System.Text.Json.Serialization;

namespace FamilyBudget.Api.ViewModels;

public sealed class ExpenditureView
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("plannedToSpendValue")]
    public decimal PlannedToSpendValue { get; set; }
    [JsonPropertyName("spentValue")]
    public decimal SpentValue { get; set; }
    [JsonPropertyName("periodId")]
    public int FinancialPeriodId { get; set; }    
    [JsonPropertyName("plannedExpenditureId")]
    public int? PlannedExpenditureId { get; set; }
}