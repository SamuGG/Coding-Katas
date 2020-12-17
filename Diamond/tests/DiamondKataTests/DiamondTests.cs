using System;
using System.Linq;
using DiamondKata;
using Xunit;

namespace DiamondKataTests
{
    public class DiamondTests
    {
        #region Helpers
        private static string FirstHalf(string value)
            => value.Substring(0, (value.Length / 2) + 1);

        private static string SecondHalf(string value)
            => value.Substring(value.Length / 2);

        private static string ReverseString(string value)
            => string.Concat(value.Reverse());
        #endregion

        [Fact]
        public void DiamondA()
        {
            Assert.Equal("A", new Diamond('A').ToLineArray()[0]);
        }

        [Fact]
        public void DiamondB()
        {
            var diamondLines = new Diamond('B').ToLineArray();
            Assert.Equal(" A ", diamondLines[0]);
            Assert.Equal("B B", diamondLines[1]);
            Assert.Equal(" A ", diamondLines[2]);
        }

        [Fact]
        public void DiamondC()
        {
            var diamondLines = new Diamond('C').ToLineArray();
            Assert.Equal("  A  ", diamondLines[0]);
            Assert.Equal(" B B ", diamondLines[1]);
            Assert.Equal("C   C", diamondLines[2]);
            Assert.Equal(" B B ", diamondLines[3]);
            Assert.Equal("  A  ", diamondLines[4]);
        }

        [Theory]
        [MemberData(nameof(TestsData.GetCharSizes), MemberType=typeof(TestsData))]
        public void Squareness(char c, int expectedSize)
        {
            var diamondLines = new Diamond(c).ToLineArray();
            Assert.Equal(expectedSize, diamondLines.Length);
            Assert.All(diamondLines, l => Assert.Equal(expectedSize, l.Length));
        }

        [Theory]
        [MemberData(nameof(TestsData.GetAllChars), MemberType = typeof(TestsData))]
        public void VerticalSymmetry(char c)
        {
            var diamondLines = new Diamond(c).ToLineArray();
            for (int i = 0, j = diamondLines.Length - 1; i <= j; i++, j--)
            {
                Assert.Equal(diamondLines[i], diamondLines[j]);
            }
        }

        [Theory]
        [MemberData(nameof(TestsData.GetAllChars), MemberType = typeof(TestsData))]
        public void HorizontalSymmetry(char c)
        {
            var diamond = new Diamond(c);
            int i = 0;
            bool finalCharReached = false;
            while (!finalCharReached && i < TestsData.AllChars.Length)
            {
                char x = TestsData.AllChars[i++];
                string line = diamond[x];
                Assert.Equal(FirstHalf(line), ReverseString(SecondHalf(line)));
                finalCharReached = x == c;
            }
            Assert.False(!finalCharReached && i >= TestsData.AllChars.Length);
        }

        [Theory]
        [MemberData(nameof(TestsData.GetAllChars), MemberType = typeof(TestsData))]
        public void PositionOfCharInLine(char c)
        {
            var diamond = new Diamond(c);
            int i = 0;
            bool finalCharReached = false;
            while (!finalCharReached && i < TestsData.AllChars.Length)
            {
                char x = TestsData.AllChars[i++];
                string firstHalf = FirstHalf(diamond[x]);
                Assert.Equal(firstHalf.Length - i, firstHalf.IndexOf(x));
                finalCharReached = x == c;
            }
            Assert.False(!finalCharReached && i >= TestsData.AllChars.Length);
        }
    }
}
