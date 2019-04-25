using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroEngine.Web.Models.Request
{
    public sealed class SynastryRequest
    {
        public DateTime BirthTimeA { get; set; }
        public DateTime BirthTimeB { get; set; }
    }
}
