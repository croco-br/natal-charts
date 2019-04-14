using AstroEngine.Domain.Entities;
using AstroEngine.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroEngine.Application
{
	public sealed class NatalChartEngine
	{
		private readonly IChartService _svc;

		public NatalChartEngine(IChartService astroEngineService)
		{
			_svc = astroEngineService;
		}

		public async Task<Chart> Calculate(DateTime birthTime)
		{
			return await _svc.ProcessNatalChart(birthTime, 0, 0);			
		}
	}
}
