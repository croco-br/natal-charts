using AstroEngine.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstroEngine.Domain.Entities
{
    public sealed class Aspect
    {
        public string Planet { get; set; }
		public double Degree { get; set; }
		public Sign Sign { get; set; }
		public bool Retrograde { get; set; }
	}
}
