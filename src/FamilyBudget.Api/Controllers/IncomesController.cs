using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FamilyBudget.Api.ViewModels;
using FamilyBudget.Domain.Entities;
using FamilyBudget.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudget.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IncomesController : ControllerBase
{
    private readonly IIncomesService _incomesService;
    private readonly IMapper _mapper;

    public IncomesController(IIncomesService incomesService, IMapper mapper)
    {
        _incomesService = incomesService;
        _mapper = mapper;
    }

    [HttpGet("Get")]
    public async Task<IReadOnlyList<IncomeView>> GetAsync([FromQuery] int periodId)
    {
        var result = await _incomesService.GetAsync(periodId);
        return _mapper.Map<IReadOnlyList<Income>, IReadOnlyList<IncomeView>>(result);
    }

    [HttpPost("SaveIncome")]
    public async Task SaveIncomeAsync([FromBody] IncomeView income)
    {
        var model = _mapper.Map<IncomeView, Income>(income);
        await _incomesService.SaveAsync(model);
    }

    [HttpPost("DeleteIncome")]
    public async Task<bool> DeleteIncomeAsync([FromQuery] int id)
    {
        return await _incomesService.DeleteByIdAsync(id);
    }
}