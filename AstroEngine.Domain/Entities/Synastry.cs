using System;
using System.Collections.Generic;
using System.Text;

namespace AstroEngine.Domain.Entities
{
    public sealed class Synastry
    {
        public Synastry()
        {
            Validations = new List<SynastryInfo>();                
        }

        public List<SynastryInfo> Validations { get; set; }

    }
}
