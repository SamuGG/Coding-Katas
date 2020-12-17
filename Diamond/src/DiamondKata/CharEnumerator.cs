using System.Collections;
using System.Collections.Generic;

namespace DiamondKata
{
    public class CharEnumerator : IEnumerator<char>
    {
        private readonly char _first;
        private readonly char _last;
        private char _current;

        public CharEnumerator(char first, char last)
        {
            _first = first;
            _last = last;
            _current = _first;
        }

        public char Current 
            => _current;

        object IEnumerator.Current 
            => Current;

        public bool MoveNext()
        {
            if (_current < _last)
            {
                _current = NextChar(_current);
                return true;
            }
            return false;
        }

        private static char NextChar(char c)
            => (char)((byte)c + 1);

        public void Reset() 
            => _current = _first;

        public void Dispose() {}
    }
}