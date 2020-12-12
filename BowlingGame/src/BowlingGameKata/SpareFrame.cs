using System.Collections.Generic;

namespace BowlingGameKata
{
    public class SpareFrame : Frame
    {
        public SpareFrame(
            IList<int> throws, 
            int firstThrow, 
            int secondThrow) : 
            base(throws, 2)
        {
            _throwsData.AddBall(firstThrow);
            _throwsData.AddBall(secondThrow);
        }
        
        public override int CalculateScore()
            => 10 + _throwsData.FirstBonusBall();
    }
}