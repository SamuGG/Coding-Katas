using System.Collections.Generic;

namespace BowlingGameKata
{
    public class OpenFrame : Frame
    {
        public OpenFrame(
            IList<int> throws, 
            int firstThrow, 
            int secondThrow) : 
            base(throws, 2)
        {
            _throwsData.AddBall(firstThrow);
            _throwsData.AddBall(secondThrow);
        }
        
        public override int CalculateScore() 
            => _throwsData.FirstBall() + _throwsData.SecondBall();
    }
}