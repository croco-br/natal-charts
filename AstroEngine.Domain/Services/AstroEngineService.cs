using AstroEngine.Domain.Entities;
using AstroEngine.Domain.Enums;
using AstroEngine.Domain.Interfaces;
using SwissEphNet;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroEngine.Domain.Services
{
    public sealed class AstroEngineService : IAstroEngineService
    {
        private readonly SwissEph _engine;

        public AstroEngineService()
        {
            _engine = new SwissEph();
            _engine.swe_set_ephe_path(null);
        }

        public async Task<Chart> ProcessNatalChart(DateTime birthTime, double latitude, double longitude)
        {
            double julianDay = GetJulianDayEphemerisTime(birthTime);

            List<Aspect> aspects = new List<Aspect>();

            for (int planetNumber = (int)Planet.SUN; planetNumber < (int)Planet.TRUE_NODE; planetNumber++)
            {
                aspects.Add(GetAspect(julianDay, planetNumber, latitude, longitude));
            }

            return new Chart()
            {
                Aspects = aspects,
                Date = birthTime,
                Latitude = latitude,
                Longitude = longitude
            };
        }

        private double GetJulianDayEphemerisTime(DateTime birthTime)
        {
            //get julian day - OK
            double julianDay = _engine.swe_julday(birthTime.Year, birthTime.Month, birthTime.Day, ParseTime(birthTime), SwissEph.SE_GREG_CAL);
            double delta = _engine.swe_deltat(julianDay);
            double julianDay_ET = julianDay + delta;
            return julianDay;
        }

        private Aspect GetAspect(double julianDay, int current, double latitude, double longitude)
        {
            double[] calculations = new double[6];
            double[] cusps = new double[13];
            double[] ascmc = new double[10];
            string error = string.Empty;
            int result = _engine.swe_calc(julianDay, current, SwissEph.SEFLG_SPEED, calculations, ref error);
            string planetName = _engine.swe_get_planet_name(current);

            return new Aspect()
            {
                Planet = planetName,
                Sign = new Sign(calculations[0])
            };
        }

        private double GetHouses(double[] houses)
        {
            foreach (var house in houses)
            {
                int signNumber = (int)house / 30;
                //TODO: calculate houses correctly
            }
            return 0.0;

        }



        private double ParseTime(DateTime dt)
        {
            double calculatedHour = dt.Hour + (dt.Minute / 60.0) + (dt.Second / 3600.0);
            return calculatedHour;
        }
    }
}
