using AstroEngine.Domain.Entities;
using AstroEngine.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace AstroEngine.Application
{
	public sealed class NatalChartEngine
	{
		private readonly IAstroEngineService _svc;

		public NatalChartEngine(IAstroEngineService astroEngineService)
		{
			_svc = astroEngineService;
		}

		public List<Aspect> Calculate(DateTime birthTime)
		{
			List<Aspect> aspects = _svc.ProcessNatalChart(birthTime, 0, 0);
			return aspects;
		}
	}
}
