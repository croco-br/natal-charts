using System;
using System.Collections.Generic;
using System.Text;

namespace AstroEngine.Domain.Entities
{
    public sealed class Chart
    {
        public DateTime Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Aspect> Aspects { get; set; }
    }
}
