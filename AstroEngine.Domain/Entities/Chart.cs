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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(4096);
            foreach (var aspect in Aspects)
            {
                sb.AppendLine(string.Format("{0} : {1}", aspect.Planet.Name.ToString(), aspect.Sign.Name.ToString()));
            }
            return sb.ToString();
        }
    }
}
