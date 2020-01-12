using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;
using FamilyBudget.Domain.Interfaces;
using FamilyBudget.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace FamilyBudget.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BudgetPeriodsController : ControllerBase
    {
        private readonly ILogger<BudgetPeriodsController> _logger;
        private readonly IFinancialPeriodService _financialPeriodService;

        public BudgetPeriodsController(ILogger<BudgetPeriodsController> logger, IFinancialPeriodService financialPeriodService)
        {
            _logger = logger;
            _financialPeriodService = financialPeriodService;
        }


        [HttpGet]
        public async Task<IReadOnlyList<FinancialPeriod>> Get()
        {
            return await _financialPeriodService.GetAll();
        }
    }
}