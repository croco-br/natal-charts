using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AstroEngine.Application;
using AstroEngine.Domain.Entities;
using AstroEngine.Domain.Interfaces.Applications;
using AstroEngine.Domain.Interfaces.Services;
using AstroEngine.Web.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstroEngine.Web.Controllers
{
    [Route("api/[controller]")]    
    public class ChartController : Controller
    {
        private readonly INatalChartEngine _app;

        public ChartController(INatalChartEngine engine)
        {
            _app = engine;
        }

        public async Task<ActionResult> Calculate(CalculateRequest request)
        {
            return Ok(await _app.Calculate(request.BirthTime));
        }

    }
}