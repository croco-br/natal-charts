using AstroEngine.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstroEngine.Domain.Entities
{
    public sealed class Sign
    {
        public Sign(double calculatedPosition)
        {
            SetSignInfo(calculatedPosition);
        }

        public Enums.Sign.Name Name { get; private set; }
        public Enums.Sign.Element Element { get; private set; }
        public Enums.Sign.Quality Quality { get; private set; }

        private void SetSignInfo(double position)
        {
            int signNumber = (int)position / 30;
            switch (signNumber)
            {
                case 0:
                    Name = Enums.Sign.Name.ARIES;
                    Element = Enums.Sign.Element.FIRE;
                    Quality = Enums.Sign.Quality.CARDINAL;
                    break;

                case 1:
                    Name = Enums.Sign.Name.TAURUS;
                    Element = Enums.Sign.Element.EARTH;
                    Quality = Enums.Sign.Quality.FIXED;
                    break;
                case 2:
                    Name = Enums.Sign.Name.GEMINI;
                    Element = Enums.Sign.Element.AIR;
                    Quality = Enums.Sign.Quality.MUTABLE;
                    break;
                case 3:
                    Name = Enums.Sign.Name.CANCER;
                    Element = Enums.Sign.Element.WATER;
                    Quality = Enums.Sign.Quality.CARDINAL;
                    break;
                case 4:
                    Name = Enums.Sign.Name.LEO;
                    Element = Enums.Sign.Element.FIRE;
                    Quality = Enums.Sign.Quality.FIXED;
                    break;
                case 5:
                    Name = Enums.Sign.Name.VIRGO;
                    Element = Enums.Sign.Element.EARTH;
                    Quality = Enums.Sign.Quality.MUTABLE;
                    break;
                case 6:
                    Name = Enums.Sign.Name.LIBRA;
                    Element = Enums.Sign.Element.AIR;
                    Quality = Enums.Sign.Quality.CARDINAL;
                    break;
                case 7:
                    Name = Enums.Sign.Name.SCORPIO;
                    Element = Enums.Sign.Element.WATER;
                    Quality = Enums.Sign.Quality.FIXED;
                    break;
                case 8:
                    Name = Enums.Sign.Name.SAGITTARIUS;
                    Element = Enums.Sign.Element.FIRE;
                    Quality = Enums.Sign.Quality.MUTABLE;
                    break;
                case 9:
                    Name = Enums.Sign.Name.CAPRICORN;
                    Element = Enums.Sign.Element.EARTH;
                    Quality = Enums.Sign.Quality.CARDINAL;
                    break;
                case 10:
                    Name = Enums.Sign.Name.AQUARIUS;
                    Element = Enums.Sign.Element.AIR;
                    Quality = Enums.Sign.Quality.FIXED;
                    break;
                case 11:
                    Name = Enums.Sign.Name.PISCES;
                    Element = Enums.Sign.Element.WATER;
                    Quality = Enums.Sign.Quality.MUTABLE;
                    break;
            }
        }
    }
}
