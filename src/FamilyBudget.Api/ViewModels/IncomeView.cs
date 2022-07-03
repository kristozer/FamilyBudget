using System.Text.Json.Serialization;

namespace FamilyBudget.Api.ViewModels;

public sealed class IncomeView
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("value")]
    public int Value { get; set; }
    [JsonPropertyName("periodId")]
    public int FinancialPeriodId { get; set; }
}