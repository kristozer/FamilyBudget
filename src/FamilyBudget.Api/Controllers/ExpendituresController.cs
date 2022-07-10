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
public class ExpendituresController
{
    private readonly IExpendituresService _expendituresService;
    private readonly IMapper _mapper;
    
    public ExpendituresController(IExpendituresService expendituresService, IMapper mapper)
    {
        _expendituresService = expendituresService;
        _mapper = mapper;
    }
    
    [HttpGet("Get")]
    public async Task<IReadOnlyList<ExpenditureView>> GetAsync([FromQuery] int periodId)
    {
        var result = await _expendituresService.GetAsync(periodId);
        return _mapper.Map<IReadOnlyList<Expenditure>, IReadOnlyList<ExpenditureView>>(result);
    }

    [HttpPost("SaveExpenditure")]
    public async Task SaveExpenditureAsync([FromBody] ExpenditureView expenditure)
    {
        var model = _mapper.Map<ExpenditureView, Expenditure>(expenditure);

        var task = expenditure.Id == 0
            ? _expendituresService.SaveAsync(model)
            : _expendituresService.UpdateAsync(model);
        await task;
    }

    [HttpPost("DeleteExpenditure")]
    public async Task<bool> DeleteExpenditureAsync([FromQuery] int id)
    {
        return await _expendituresService.DeleteByIdAsync(id);
    }
}