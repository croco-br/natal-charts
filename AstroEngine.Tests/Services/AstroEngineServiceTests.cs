using AstroEngine.Domain;
using AstroEngine.Domain.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AstroEngine.Tests.Services
{
    public class AstroEngineTests
    {
        [Fact]
        public async Task ShouldDoBasicCalculationScenario1()
        {
            AstroEngineService svc = new Domain.Services.AstroEngineService();
            var chart = await svc.ProcessNatalChart(new DateTime(1990, 06, 25, 22, 15, 00), -23.5489, -46.6388);

            Assert.True(
                chart.Aspects[0].Planet == "Sun" &&
                chart.Aspects[0].Sign.Name == Domain.Enums.Sign.Name.CANCER &&
                chart.Aspects[4].Planet == "Mars" &&
                chart.Aspects[4].Sign.Name == Domain.Enums.Sign.Name.ARIES &&
                chart.Aspects[9].Planet == "Pluto" &&
                chart.Aspects[9].Sign.Name == Domain.Enums.Sign.Name.SCORPIO);
        }

        [Fact]
        public async Task ShouldDoBasicCalculationScenario2()
        {
            AstroEngineService svc = new Domain.Services.AstroEngineService();
            var chart = await svc.ProcessNatalChart(new DateTime(1989, 07, 07, 17, 30, 00), -23.5489, -46.6388);

            Assert.True(
                chart.Aspects[0].Planet == "Sun" &&
                chart.Aspects[0].Sign.Name == Domain.Enums.Sign.Name.CANCER &&
                chart.Aspects[4].Planet == "Mars" &&
                chart.Aspects[4].Sign.Name == Domain.Enums.Sign.Name.LEO &&
                chart.Aspects[9].Planet == "Pluto" &&
                chart.Aspects[9].Sign.Name == Domain.Enums.Sign.Name.SCORPIO);
        }

        [Fact]
        public async Task ShouldDoBasicCalculationScenario3()
        {
            AstroEngineService svc = new AstroEngineService();
            var chart = await svc.ProcessNatalChart(new DateTime(1980, 12, 22, 15, 00, 00), -23.5489, -46.6388);

            Assert.True(
                chart.Aspects[0].Planet == "Sun" &&
                chart.Aspects[0].Sign.Name == Domain.Enums.Sign.Name.CAPRICORN &&
                chart.Aspects[4].Planet == "Mars" &&
                chart.Aspects[4].Sign.Name == Domain.Enums.Sign.Name.CAPRICORN &&
                chart.Aspects[9].Planet == "Pluto" &&
                chart.Aspects[9].Sign.Name == Domain.Enums.Sign.Name.LIBRA);
        }
    }
}
