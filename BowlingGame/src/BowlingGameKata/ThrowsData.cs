using System.Collections.Generic;

namespace BowlingGameKata
{
    public class ThrowsData
    {
        private readonly IList<int> _data;
        private readonly int _startIndex;
        private readonly int _frameSize;
        
        public ThrowsData(IList<int> data, int startIndex, int frameSize)
        {
            _data = data;
            _startIndex = startIndex;
            _frameSize = frameSize;
        }

        public void AddBall(int ball) => _data.Add(ball);

        public int FirstBall() => _data[_startIndex];
        public int SecondBall() => _data[_startIndex + 1];

        public int FirstBonusBall() => _data[_startIndex + _frameSize]; 
        public int SecondBonusBall() => _data[_startIndex + _frameSize + 1]; 
    }
}