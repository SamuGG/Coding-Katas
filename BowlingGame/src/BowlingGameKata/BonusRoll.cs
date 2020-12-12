using System.Collections.Generic;

namespace BowlingGameKata
{
    public class BonusRoll : Frame
    {
        public BonusRoll(IList<int> throws, int firstThrow) : base(throws, 0)
            => _throwsData.AddBall(firstThrow);

        public override int CalculateScore() => 0;
    }
}