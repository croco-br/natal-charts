using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AstroEngine.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstroEngine.Controllers
{
    [Route("api/[controller]")]
    public class AspectController : Controller
    {
		private readonly IAstroEngineService _service;

		public AspectController(IAstroEngineService astroEngineService)
		{
			_service = astroEngineService;
		}


        [HttpGet]
        public async Task<IActionResult> Get(DateTime birthTime)
        {
			var aspects = await _service.ProcessNatalChart(birthTime, 0, 0);
			return Ok(aspects);
			
        }        
    }
}
