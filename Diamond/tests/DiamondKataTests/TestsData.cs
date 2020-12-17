using Xunit;

namespace DiamondKataTests
{
    public class TestsData
    {
        public static readonly char[] AllChars = 
        { 
            'A', 
            'B', 
            'C', 
            'D', 
            'E', 
            'F', 
            'G', 
            'H', 
            'I', 
            'J', 
            'K', 
            'L', 
            'M', 
            'N', 
            'O', 
            'P', 
            'Q', 
            'R', 
            'S', 
            'T', 
            'U', 
            'V', 
            'W', 
            'X', 
            'Y', 
            'Z'
        };

        public static TheoryData<char> GetAllChars()
        {
            var data = new TheoryData<char>();
            foreach(char c in AllChars) 
                data.Add(c);
            return data;
        }

        public static TheoryData<char, int> GetCharSizes()
        {
            var data = new TheoryData<char, int>();
            for (int i = 0, j = 1; i < AllChars.Length; i++, j += 2)
                data.Add(AllChars[i], j);
            return data;
        }
    }
}