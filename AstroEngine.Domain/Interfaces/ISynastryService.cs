using AstroEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AstroEngine.Domain.Interfaces
{
    public interface ISynastryService
    {
        Task<SynastryResult> Compare(Chart a, Chart b);
    }
}
