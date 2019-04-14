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

		public async Task<List<Aspect>> ProcessNatalChart(DateTime birthTime, double latitude, double longitude)
		{
			double julianDay = GetJulianDayEphemerisTime(birthTime);

			List<Aspect> aspects = new List<Aspect>();

			for (int planetNumber = (int)Planet.SUN; planetNumber < (int)Planet.TRUE_NODE; planetNumber++)
			{
				aspects.Add(GetAspect(julianDay, planetNumber, latitude, longitude));
			}

			return aspects;
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
				Sign = GetSign(calculations[0])
			};
		}

		private double GetHouses(double[] houses)
		{
			foreach (var house in houses)
			{
				int signNumber = (int)house / 30;
			
			}
			return 0.0;

		}

		private string GetSign(double position)
		{
			int signNumber = (int)position / 30;
			switch (signNumber)
			{
				case 0: return "Aries";
				case 1: return "Taurus";
				case 2: return "Gemini";
				case 3: return "Cancer";
				case 4: return "Leo";
				case 5: return "Virgo";
				case 6: return "Libra";
				case 7: return "Scorpio";
				case 8: return "Sagittarius";
				case 9: return "Capricorn";
				case 10: return "Aquarius";
				case 11: return "Pisces";
				default:
					throw new Exception("Get Sign Error");
			}
		}

		private double ParseTime(DateTime dt)
		{
			double calculatedHour = dt.Hour + (dt.Minute / 60.0) + (dt.Second / 3600.0);
			return calculatedHour;
		}



		
	}
}
