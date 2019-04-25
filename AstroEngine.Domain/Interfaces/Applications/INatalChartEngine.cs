using AstroEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AstroEngine.Domain.Interfaces.Applications
{
    public interface INatalChartEngine
    {
        Task<Chart> Calculate(DateTime birthTime);
        Task<Synastry> CompareCharts(DateTime a, DateTime b);
    }
}
