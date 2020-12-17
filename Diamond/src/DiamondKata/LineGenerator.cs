using System.Text;

namespace DiamondKata
{
    public class LineGenerator
    {
        private const char WhiteSpace = ' ';
        private readonly int _size;

        public LineGenerator(int size)
            => _size = size;

        public string Generate(char c, CharIndices indices)
        {
            StringBuilder builder = new();
            
            for(int i = 0; i < indices.Left; i++)
                builder.Append(WhiteSpace);
            
            builder.Append(c);
            
            for(int i = indices.Left + 1; i < indices.Right; i++)
                builder.Append(WhiteSpace);
            
            if (indices.Right > indices.Left)
                builder.Append(c);
                
            for(int i = indices.Right + 1; i < _size; i++)
                builder.Append(WhiteSpace);
            
            return builder.ToString();
        }
    }
}