using System.Collections.Generic;

namespace BowlingGameKata
{
    public class StrikeFrame : Frame
    {
        public StrikeFrame(IList<int> throws) : base(throws, 1)
            => _throwsData.AddBall(10);

        public override int CalculateScore() 
            => 10 + _throwsData.FirstBonusBall() + _throwsData.SecondBonusBall();
    }
}