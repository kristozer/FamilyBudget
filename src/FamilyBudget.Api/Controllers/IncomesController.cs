using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;
using FamilyBudget.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudget.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IncomesController : ControllerBase
{
    private readonly IIncomesService _incomesService;

    public IncomesController(IIncomesService incomesService)
    {
        _incomesService = incomesService;
    }

    [HttpGet("Get")]
    public Task<IReadOnlyList<Income>> GetAsync(int periodId)
    {
        return _incomesService.GetAsync(periodId);
    }
}