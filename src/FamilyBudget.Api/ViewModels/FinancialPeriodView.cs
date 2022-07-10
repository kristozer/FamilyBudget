using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FamilyBudget.Domain.Entities;

namespace FamilyBudget.Api.ViewModels;

public sealed class FinancialPeriodView
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("periodBegin")]
    public DateTime PeriodBegin { get; set; }
    [JsonPropertyName("periodEnd")]
    public DateTime PeriodEnd { get; set; }
    [JsonPropertyName("incomes")]
    public List<Income> Incomes { get; set; }
    [JsonPropertyName("expenditures")]
    public List<Expenditure> Expenditures { get; set; }
}