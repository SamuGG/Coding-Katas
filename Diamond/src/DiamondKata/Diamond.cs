using System.Linq;

namespace DiamondKata
{
    public class Diamond
    {
        private readonly LineCollection _lines = new();
        private readonly char[] _lineKeys;

        public Diamond(char c)
        {
            new DiamondGenerator('A', c).WriteTo(_lines);
            _lineKeys = _lines.GetKeysInOrder()
                .Concat(_lines.GetKeysInOrder().Reverse().Skip(1))
                .ToArray();
        }

        public string this[char c]
            => _lines[c];

        public string[] ToLineArray()
            => _lineKeys.Select(c => _lines[c]).ToArray();
    }
}