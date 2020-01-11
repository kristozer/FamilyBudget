using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public BudgetPeriodsController(ILogger<BudgetPeriodsController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public string Get()
        {
            return "test";
        }
    }
}