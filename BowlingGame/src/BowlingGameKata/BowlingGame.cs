using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata
{
    public class BowlingGame
    {
        private readonly List<int> _throws = new();
        private readonly List<Frame> _frames = new();

        public void OpenFrame(int firstThrow, int secondThrow)
            => _frames.Add(new OpenFrame(_throws, firstThrow, secondThrow));

        public void Spare(int firstThrow, int secondThrow)
            => _frames.Add(new SpareFrame(_throws, firstThrow, secondThrow));

        public void Strike()
            => _frames.Add(new StrikeFrame(_throws));

        public void BonusRoll(int @throw)
            => _frames.Add(new BonusRoll(_throws, @throw));

        public int TotalScore() => _frames.Sum(f => f.CalculateScore());
    }
}