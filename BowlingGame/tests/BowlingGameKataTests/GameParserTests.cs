using BowlingGameKata;
using Xunit;

namespace BowlingGameKataTests
{
    public class GameParserTests
    {
        [Fact]
        public void PerfectScore()
        {
            Assert.Equal(300, GameParser.Parse("x x x x x x x x x x x x"));
        }

        [Fact]
        public void NineAndMiss()
        {
            Assert.Equal(90, GameParser.Parse("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-"));
        }

        [Fact]
        public void SpareFrames()
        {
            Assert.Equal(150, GameParser.Parse("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5"));
        }
    }
}