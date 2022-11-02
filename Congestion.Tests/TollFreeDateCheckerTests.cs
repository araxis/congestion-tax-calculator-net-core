using congestion.calculator;
using FluentAssertions;
using Moq;

namespace Congestion.Tests
{
    public class TollFreeDateCheckerTests
    {
        [Theory]
        [InlineData("2022,11,5")]
        [InlineData("2022,10,30")]
        public void WhenDayBeWeekendAndFreeOnWeekendIsTrueIsFreeTollDayIsTrue(string dateString)
        {
            var holidayChecker = new Mock<IHolidayChecker>();
            var date = DateTime.Parse(dateString);
            holidayChecker.Setup(a => a.IsHoliday(date)).Returns(true);
            var tollFreeDateChecker = new TollFreeDateChecker(holidayChecker.Object);
            var config = new CongestionTollConfigs
            {
                FreeOnWeekend = true
            };
            var result = tollFreeDateChecker.IsTollFreeDate(date,config);
            result.Should().BeTrue();
        }
    }
}