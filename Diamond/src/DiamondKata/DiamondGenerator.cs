namespace DiamondKata
{
    public class DiamondGenerator
    {
        private readonly char _initialChar;
        private readonly char _finalChar;

        public DiamondGenerator(char initialChar, char finalChar)
            => (_initialChar, _finalChar) = (initialChar, finalChar);

        public void WriteTo(LineCollection lines)
        {
            int lineLength = new LineLength(_initialChar).To(_finalChar);
            using CharEnumerator enumerator = new(_initialChar, _finalChar);
            LineGenerator generator = new(lineLength);
            CharIndices charIndices = new(lineLength);
            charIndices.Center();
            lines.Add(enumerator.Current, generator.Generate(enumerator.Current, charIndices));
            while(enumerator.MoveNext())
            {
                charIndices.Widen();
                lines.Add(enumerator.Current, generator.Generate(enumerator.Current, charIndices));
            }
        }
    }
}
