using AstroEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AstroEngine.Domain.Interfaces.Services
{
    public interface IChartService
    {
        Task<Chart> ProcessNatalChart(DateTime birthTime, double latitude, double longitude);
    }
}
