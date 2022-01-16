using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;
using FamilyBudget.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FamilyBudget.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BudgetPeriodsController : ControllerBase
{
    private readonly ILogger<BudgetPeriodsController> _logger;
    private readonly IFinancialPeriodService _financialPeriodService;

    public BudgetPeriodsController(ILogger<BudgetPeriodsController> logger,
        IFinancialPeriodService financialPeriodService)
    {
        _logger = logger;
        _financialPeriodService = financialPeriodService;
    }


    [HttpGet]
    public async Task<IReadOnlyList<FinancialPeriod>> Get()
    {
        return await _financialPeriodService.GetAll();
    }

    [HttpPost]
    public async Task Post()
    {
        var data = new FinancialPeriod
        {
            Name = "Second",
            PeriodBegin = new DateTime(2022, 1, 1),
            PeriodEnd = new DateTime(2022, 6, 30),
            Incomes = new List<Income>
            {
                new Income
                {
                    Name = "First",
                    Value = 12,
                    FinancialPeriodId = 2
                }
            },
            Expenditures = new List<Expenditure>()
        };

        await _financialPeriodService.Save(data);
    }
}