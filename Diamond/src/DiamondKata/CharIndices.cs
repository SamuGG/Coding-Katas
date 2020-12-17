namespace DiamondKata
{
    public class CharIndices
    {
        private readonly int _length;

        public int Left { get; private set; }
        public int Right { get; private set; }

        public CharIndices(int length)
            => _length = length;

        public void Widen()
        {
            if (Left > 0) Left--;
            if (Right < _length) Right++;
        }

        public void Center()
        {
            Left = _length / 2;
            Right = Left;
        }
    }
}