using System.Collections.Generic;

namespace BowlingGameKata
{
    public abstract class Frame
    {
        protected readonly ThrowsData _throwsData;

        private Frame() {}
        protected Frame(IList<int> throws, int frameSize) 
            => _throwsData = new ThrowsData(throws, throws.Count, frameSize);

        public abstract int CalculateScore();
        
        protected int FirstBonusBall() => _throwsData.FirstBonusBall();
        protected int SecondBonusBall() => _throwsData.SecondBonusBall();
    }
}