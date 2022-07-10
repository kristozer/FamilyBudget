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
    [Route("GetAll")]
    public async Task<IReadOnlyList<FinancialPeriod>> GetAll()
    {
        return await _financialPeriodService.GetAllAsync();
    }
    
    [HttpGet]
    public async Task<IReadOnlyList<FinancialPeriod>> Get()
    {
        return await _financialPeriodService.GetSomeAsync(4);
    }

    [HttpPost]
    public async Task Post()
    {
        var data = new FinancialPeriod
        {
            PeriodBegin = new DateTime(2022, 7, 1),
            PeriodEnd = new DateTime(2022, 7, 15),
            Incomes = new List<Income>
            {
                new Income
                {
                    Name = "First",
                    Value = 12,
                    FinancialPeriodId = 1
                }
            },
            Expenditures = new List<Expenditure>()
        };

        await _financialPeriodService.Save(data);
    }
}