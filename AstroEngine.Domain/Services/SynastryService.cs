using AstroEngine.Domain.Entities;
using AstroEngine.Domain.Enums;
using AstroEngine.Domain.Interfaces;
using SwissEphNet;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroEngine.Domain.Services
{
    public sealed class SynastryService : ISynastryService
    {
        private const int POSITIVE = 1;
        private const int NEUTRAL = 0;
        private const int NEGATIVE = -1;

        public async Task<Synastry> Compare(Chart primary, Chart secondary)
        {
            var synastryResult = new Synastry();
            synastryResult.Validations.AddRange(GetPlanetInfo(primary, secondary));
            synastryResult.Validations.AddRange(GetPlanetInfo(primary, secondary));
            return synastryResult;
        }

        private List<SynastryInfo> GetPlanetInfo(Chart primary, Chart second)
        {
            if (primary.Aspects.Count != second.Aspects.Count)
            {
                throw new Exception("The charts must have the same quantity of aspects");
            }

            List<SynastryInfo> validations = new List<SynastryInfo>();

            for (int i = 0; i < primary.Aspects.Count; i++)
            {
                var current = primary.Aspects[i];
                var compared = second.Aspects[i];

                if (current.Planet.Name == compared.Planet.Name)
                {
                    if (current.Sign.Element == compared.Sign.Element)
                    {
                        validations.Add(new SynastryInfo()
                        {
                            Description = string.Format("the {0} have the same sign element", current.Planet.Name.ToString()),
                            Score = POSITIVE
                        });                        
                    }
                    else
                    {
                        validations.Add(new SynastryInfo()
                        {
                            Description = string.Format("the {0} doesn't have the same sign element", current.Planet.Name.ToString()),
                            Score = NEUTRAL
                        });
                    }
                }
            }

            return validations;
        }
    }
}