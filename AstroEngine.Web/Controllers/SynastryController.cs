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
    public class SynastryController : Controller
    {
        private readonly INatalChartEngine _app;

        public SynastryController(INatalChartEngine engine)
        {
            _app = engine;
        }

        public async Task<ActionResult> Calculate(SynastryRequest request)
        {
            return Ok(await _app.CompareCharts(request.BirthTimeA, request.BirthTimeB));
        }

    }
}