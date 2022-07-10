using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FamilyBudget.Api.ViewModels;
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
    private readonly IMapper _mapper;

    public BudgetPeriodsController(ILogger<BudgetPeriodsController> logger,
        IFinancialPeriodService financialPeriodService, IMapper mapper)
    {
        _logger = logger;
        _financialPeriodService = financialPeriodService;
        _mapper = mapper;
    }


    [HttpGet]
    [Route("GetAll")]
    public async Task<IReadOnlyList<FinancialPeriodView>> GetAll()
    {
        var result = await _financialPeriodService.GetAllAsync();
        return _mapper.Map<IReadOnlyList<FinancialPeriod>, IReadOnlyList<FinancialPeriodView>>(result);
    }
    
    [HttpGet]
    public async Task<IReadOnlyList<FinancialPeriodView>> Get()
    {
        var result = await _financialPeriodService.GetSomeAsync(4);
        return _mapper.Map<IReadOnlyList<FinancialPeriod>, IReadOnlyList<FinancialPeriodView>>(result);
    }

    [HttpPost("SavePeriod")]
    public async Task SavePeriodAsync(FinancialPeriodView periodView)
    {
        var model = _mapper.Map<FinancialPeriodView, FinancialPeriod>(periodView);

        var task = periodView.Id == 0
            ? _financialPeriodService.SaveAsync(model)
            : _financialPeriodService.UpdateAsync(model);
        await task;
    }
    
    [HttpPost("DeletePeriod")]
    public async Task<bool> DeletePeriodAsync([FromQuery] int id)
    {
        return await _financialPeriodService.DeleteByIdAsync(id);
    }
}