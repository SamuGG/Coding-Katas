using System;
using BirthdayGreetingsKata.IO;
using Moq;
using Xunit;

namespace BirthdayGreetingsKataTests.IO
{
    public class AnniversaryCheckerTests
    {
        private static Mock<IDateProvider> MockDateProvider(DateTime currentDate)
        {
            var mock = new Mock<IDateProvider>();
            mock.SetupGet(provider => provider.Date).Returns(currentDate);
            return mock;
        }

        public static TheoryData<DateTime, DateTime, bool> GetYearsComparisonData()
        {
            var data = new TheoryData<DateTime, DateTime, bool>();
            data.Add(new DateTime(2000, 1, 1), new DateTime(2000, 1, 1), false);
            data.Add(new DateTime(2001, 1, 1), new DateTime(2000, 1, 1), true);
            return data;
        }
        
        [Theory]
        [MemberData(nameof(GetYearsComparisonData))]
        public void IsAnniversaryWhenCurrentYearIsGreater(DateTime currentDate, DateTime candidate, bool expectedResult)
        {
            Assert.Equal(expectedResult, new AnniversaryChecker(MockDateProvider(currentDate).Object).IsBirthday(candidate));
        }

        public static TheoryData<DateTime, DateTime, bool> GetDayAndMonthComparisonData()
        {
            var data = new TheoryData<DateTime, DateTime, bool>();
            data.Add(new DateTime(2001, 1, 2), new DateTime(2000, 1, 1), false);
            data.Add(new DateTime(2001, 1, 2), new DateTime(2000, 2, 2), false);
            data.Add(new DateTime(2001, 1, 2), new DateTime(2000, 2, 1), false);
            data.Add(new DateTime(2001, 1, 2), new DateTime(2000, 1, 2), true);
            return data;
        }
        
        [Theory]
        [MemberData(nameof(GetDayAndMonthComparisonData))]
        public void IAnniversaryWhenCurrentDayAndMonthAreEqual(DateTime currentDate, DateTime candidate, bool expectedResult)
        {
            Assert.Equal(expectedResult, new AnniversaryChecker(MockDateProvider(currentDate).Object).IsBirthday(candidate));
        }

        public static TheoryData<DateTime, DateTime, bool> GetLeapYearComparisonData()
        {
            var data = new TheoryData<DateTime, DateTime, bool>();
            data.Add(new DateTime(2004, 2, 28), new DateTime(2000, 2, 29), false);
            data.Add(new DateTime(2001, 2, 28), new DateTime(2000, 2, 28), true);
            data.Add(new DateTime(2001, 2, 28), new DateTime(2000, 2, 29), true);
            return data;
        }
        
        [Theory]
        [MemberData(nameof(GetLeapYearComparisonData))]
        public void IsAnniversaryWhenCandidateAndCurrentAreTheLastDayOfFebruary(DateTime currentDate, DateTime candidate, bool expectedResult)
        {
            Assert.Equal(expectedResult, new AnniversaryChecker(MockDateProvider(currentDate).Object).IsBirthday(candidate));
        }
    }
}