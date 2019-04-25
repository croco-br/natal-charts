using AstroEngine.Domain.Entities;
using AstroEngine.Domain.Enums;
using AstroEngine.Domain.Interfaces;
using AstroEngine.Domain.Interfaces.Services;
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

            if (primary.Aspects.Count != secondary.Aspects.Count)
            {
                throw new Exception("The charts must have the same quantity of aspects");
            }

            synastryResult.Validations.AddRange(GetPlanetInfo(primary, secondary));
            synastryResult.Validations.AddRange(GetActiveVenusInfo(primary, secondary));
            synastryResult.Validations.AddRange(GetReceptiveMoonInfo(primary, secondary));

            return synastryResult;
        }

        private List<SynastryInfo> GetPlanetInfo(Chart primary, Chart secondary)
        {

            List<SynastryInfo> validations = new List<SynastryInfo>();

            for (int i = 0; i < primary.Aspects.Count; i++)
            {
                var current = primary.Aspects[i];
                var compared = secondary.Aspects[i];

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

        private List<SynastryInfo> GetActiveVenusInfo(Chart primary, Chart second)
        {
            List<SynastryInfo> validations = new List<SynastryInfo>();

            var venus = primary.Aspects.Find(x => x.Planet.Name == Enums.Planet.Description.VENUS);
            var moon = second.Aspects.Find(x => x.Planet.Name == Enums.Planet.Description.MOON);

            validations.Add(venus.Sign == moon.Sign ? new SynastryInfo()
            {
                Description = "Active Venus",
                Score = POSITIVE
            } :
            new SynastryInfo()
            {
                Description = "Bad Venus",
                Score = NEGATIVE
            });

            return validations;
        }

        private List<SynastryInfo> GetReceptiveMoonInfo(Chart primary, Chart second)
        {
            List<SynastryInfo> validations = new List<SynastryInfo>();

            var moon = primary.Aspects.Find(x => x.Planet.Name == Enums.Planet.Description.MOON);
            var venus = second.Aspects.Find(x => x.Planet.Name == Enums.Planet.Description.VENUS);

            validations.Add(venus.Sign == moon.Sign ? new SynastryInfo()
            {
                Description = "Receptive moon",
                Score = POSITIVE
            } :
            new SynastryInfo()
            {
                Description = "Bad moon",
                Score = NEGATIVE
            });

            return validations;
        }

        private List<SynastryInfo> GetIdentityInfo(Chart primary, Chart secondary)
        {
            List<SynastryInfo> validations = new List<SynastryInfo>();

            var sun = primary.Aspects.Find(x => x.Planet.Name == Enums.Planet.Description.SUN);

            for (int i = 0; i < secondary.Aspects.Count; i++)
            {
                var compared = secondary.Aspects[i];

                switch (compared.Sign.Name)
                {
                    case Enums.Sign.Name.ARIES:
                        break;
                    case Enums.Sign.Name.TAURUS:
                        break;
                    case Enums.Sign.Name.GEMINI:
                        break;
                    case Enums.Sign.Name.CANCER:
                        break;
                    case Enums.Sign.Name.LEO:
                        break;
                    case Enums.Sign.Name.VIRGO:
                        break;
                    case Enums.Sign.Name.LIBRA:
                        break;
                    case Enums.Sign.Name.SCORPIO:
                        break;
                    case Enums.Sign.Name.SAGITTARIUS:
                        break;
                    case Enums.Sign.Name.CAPRICORN:
                        break;
                    case Enums.Sign.Name.AQUARIUS:
                        break;
                    case Enums.Sign.Name.PISCES:
                        break;
                    default:
                        break;
                }

            }

            return validations;
        }

    }
}