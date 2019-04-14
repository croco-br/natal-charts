using AstroEngine.Domain;
using AstroEngine.Domain.Services;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace AstroEngine.Tests.Entities
{
    public class SignTests
    {
        [Fact]
        public async Task ShouldGetAriesInfoCorrectly()
        {
            var sign = new Domain.Entities.Sign(12.3);
            sign.Element.Should().Be(Domain.Enums.Sign.Element.FIRE);
            sign.Name.Should().Be(Domain.Enums.Sign.Name.ARIES);
            sign.Quality.Should().Be(Domain.Enums.Sign.Quality.CARDINAL);
        }

        [Fact]
        public async Task ShouldGetLibraInfoCorrectly()
        {
            var sign = new Domain.Entities.Sign(183.52);
            sign.Element.Should().Be(Domain.Enums.Sign.Element.AIR);
            sign.Name.Should().Be(Domain.Enums.Sign.Name.LIBRA);
            sign.Quality.Should().Be(Domain.Enums.Sign.Quality.CARDINAL);
        }

        [Fact]
        public async Task ShouldGetCapricornInfoCorrectly()
        {
            var sign = new Domain.Entities.Sign(270.64);
            sign.Element.Should().Be(Domain.Enums.Sign.Element.EARTH);
            sign.Name.Should().Be(Domain.Enums.Sign.Name.CAPRICORN);
            sign.Quality.Should().Be(Domain.Enums.Sign.Quality.CARDINAL);
        }

        [Fact]
        public async Task ShouldGetScorpioInfoCorrectly()
        {
            var sign = new Domain.Entities.Sign(213.66);
            sign.Element.Should().Be(Domain.Enums.Sign.Element.WATER);
            sign.Name.Should().Be(Domain.Enums.Sign.Name.SCORPIO);
            sign.Quality.Should().Be(Domain.Enums.Sign.Quality.FIXED);
        }
    }
}
