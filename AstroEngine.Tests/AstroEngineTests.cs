using AstroEngine.Domain;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AstroEngine.Tests
{
    public class AstroEngineTests
    {
        [Fact]
        public async Task ShouldDoBasicCalculationScenario1()
        {
            AstroEngineService svc = new Domain.AstroEngineService();
            var aspects = svc.ProcessNatalChart(new DateTime(1990, 06, 25, 22, 15, 00), -23.5489, -46.6388);

            Assert.True(aspects[0].Planet == "Sun" &&
                aspects[0].Sign == "Cancer" &&
                aspects[4].Planet == "Mars" &&
                aspects[4].Sign == "Aries" &&
                aspects[9].Planet == "Pluto" &&
                aspects[9].Sign == "Scorpio" );
        }

        [Fact]
        public async Task ShouldDoBasicCalculationScenario2()
        {
            AstroEngineService svc = new Domain.AstroEngineService();
            var aspects =  svc.ProcessNatalChart(new DateTime(1989, 07, 07, 17, 30, 00), -23.5489, -46.6388);

            Assert.True(aspects[0].Planet == "Sun" &&
                aspects[0].Sign == "Cancer" &&
                aspects[4].Planet == "Mars" &&
                aspects[4].Sign == "Leo" &&
                aspects[9].Planet == "Pluto" &&
                aspects[9].Sign == "Scorpio");
        }

        [Fact]
        public async Task ShouldDoBasicCalculationScenario3()
        {
            AstroEngineService svc = new Domain.AstroEngineService();
            var aspects =  svc.ProcessNatalChart(new DateTime(1980, 12, 22, 15, 00, 00), -23.5489, -46.6388);

            Assert.True(aspects[0].Planet == "Sun" &&
                aspects[0].Sign == "Capricorn" &&
                aspects[4].Planet == "Mars" &&
                aspects[4].Sign == "Capricorn" &&
                aspects[9].Planet == "Pluto" &&
                aspects[9].Sign == "Libra");
        }
    }
}
