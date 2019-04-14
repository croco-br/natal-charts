using AstroEngine.Domain.Services;
using AstroEngine.Domain;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace AstroEngine.Tests.Services
{
    public class SynastryServiceTests
    {
        [Fact]
        public async Task ShouldDoBasicSynastry()
        {
            ChartService svc = new AstroEngine.Domain.Services.ChartService();
            var chartA = await svc.ProcessNatalChart(new DateTime(1990, 06, 25, 22, 15, 00), -23.5489, -46.6388);
            var chartB = await svc.ProcessNatalChart(new DateTime(1989, 07, 07, 17, 30, 00), -23.5489, -46.6388);

            SynastryService synastryService = new SynastryService();
            var result = await synastryService.Compare(chartA, chartB);
            result.Should().NotBe(null);
        }


    }
}
