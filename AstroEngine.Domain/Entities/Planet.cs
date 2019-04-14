using AstroEngine.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstroEngine.Domain.Entities
{
    public sealed class Planet
    {
        public Planet(int planetNumber)
        {
            Name = (Enums.Planet.Description)planetNumber;
        }

        public Enums.Planet.Description Name { get; private set; }                
    }
}
