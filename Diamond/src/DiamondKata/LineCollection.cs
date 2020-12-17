using System.Collections.Generic;

namespace DiamondKata
{
    public class LineCollection
    {
        private readonly Dictionary<char, string> _charLines = new();
        private readonly List<char> _chars = new();

        public void Add(char c, string line)
        {
            _chars.Add(c);
            _charLines[c] = line;
        }

        public string this[char c]
            => _charLines[c];

        public IEnumerable<char> GetKeysInOrder()
            => _chars;
    }
}