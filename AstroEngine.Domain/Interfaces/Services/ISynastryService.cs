using AstroEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AstroEngine.Domain.Interfaces.Services
{
    public interface ISynastryService
    {
        Task<Synastry> Compare(Chart primary, Chart secondary);
    }
}
