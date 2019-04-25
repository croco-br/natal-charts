using AstroEngine.Domain.Entities;
using AstroEngine.Domain.Interfaces;
using AstroEngine.Domain.Interfaces.Applications;
using AstroEngine.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroEngine.Application
{
    public sealed class NatalChartEngine : INatalChartEngine
    {
        private readonly IChartService _chartService;
        private readonly ISynastryService _synastryService;
        public NatalChartEngine(IChartService chartService, ISynastryService synastryService)
        {
            _chartService = chartService;
            _synastryService = synastryService;
        }

        public async Task<Chart> Calculate(DateTime birthTime)
        {
            return await _chartService.ProcessNatalChart(birthTime, 0, 0);
        }

        public async Task<Synastry> CompareCharts(DateTime a, DateTime b)
        {
            var chartA = await _chartService.ProcessNatalChart(a, 0, 0);
            var chartB = await _chartService.ProcessNatalChart(b, 0, 0);

            return await _synastryService.Compare(chartA, chartB);
        }
    }
}
