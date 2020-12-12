using BowlingGameKata;
using Xunit;

namespace BowlingGameKataTests
{
    public class BowlingGameTests
    {
        private static void AddOpenFrames(
            BowlingGame game,
            int count,
            int firstThrow,
            int secondThrow)
        {
            for (int i = 0; i < count; i++)
                game.OpenFrame(firstThrow, secondThrow);
        }

        [Fact]
        public void GutterBalls()
        {
            var game = new BowlingGame();
            AddOpenFrames(game, 10, 0, 0);
            Assert.Equal(0, game.TotalScore());
        }

        [Fact]
        public void OpenFrame()
        {
            var game = new BowlingGame();
            AddOpenFrames(game, 10, 2, 3);
            Assert.Equal(50, game.TotalScore());
        }

        [Fact]
        public void SpareFrame()
        {
            var game = new BowlingGame();
            game.Spare(4, 6);
            game.OpenFrame(3, 5);
            AddOpenFrames(game, 8, 0, 0);
            Assert.Equal(21, game.TotalScore());
        }

        [Fact]
        public void StrikeFrame()
        {
            var game = new BowlingGame();
            game.Strike();
            game.OpenFrame(5, 3);
            AddOpenFrames(game, 8, 0, 0);
            Assert.Equal(26, game.TotalScore());
        }

        [Fact]
        public void StrikeFinalFrame()
        {
            var game = new BowlingGame();
            AddOpenFrames(game, 9, 0, 0);
            game.Strike();
            game.BonusRoll(5);
            game.BonusRoll(3);
            Assert.Equal(18, game.TotalScore());
        }

        [Fact]
        public void SpareFinalFrame()
        {
            var game = new BowlingGame();
            AddOpenFrames(game, 9, 0, 0);
            game.Spare(4, 6);
            game.BonusRoll(5);
            Assert.Equal(15, game.TotalScore());
        }

        [Fact]
        public void PerfectScore()
        {
            var game = new BowlingGame();
            for (int i = 0; i < 10; i++)
                game.Strike();
            game.BonusRoll(10);
            game.BonusRoll(10);
            Assert.Equal(300, game.TotalScore());
        }

        [Fact]
        public void AlternatingStrikesAndSpares()
        {
            var game = new BowlingGame();
            for (int i = 0; i < 5; i++)
            {
                game.Strike();
                game.Spare(4, 6);
            }
            game.BonusRoll(10);
            Assert.Equal(200, game.TotalScore());
        }
    }
}