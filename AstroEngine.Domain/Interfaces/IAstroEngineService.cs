using AstroEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AstroEngine.Domain.Interfaces
{
    public interface IAstroEngineService
    {
        List<Aspect> ProcessNatalChart(DateTime birthTime, double latitude, double longitude);
    }
}
