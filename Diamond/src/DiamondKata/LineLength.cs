namespace DiamondKata
{
    public class LineLength
    {
        private readonly char _origin;

        public LineLength(char origin)
            => _origin = origin;

        public int To(char to)
             => (((byte)to - (byte)_origin) * 2) + 1;
    }
}