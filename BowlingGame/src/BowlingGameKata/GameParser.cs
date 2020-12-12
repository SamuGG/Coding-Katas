namespace BowlingGameKata
{
    public static class GameParser
    {
        public static int Parse(string throws)
        {
            BowlingGame game = new();
            var frames = throws.Split(ScoreSymbols.SeparatorToken, 10);
            foreach (string frame in frames)
                AddFrame(game, frame);

            string lastFrame = frames[frames.Length - 1];
            if (lastFrame.Contains(ScoreSymbols.SeparatorToken))
            {
                foreach(string bonusRoll in GetBonusRolls(lastFrame))
                    AddBonusRoll(game, bonusRoll);
            }
                
            return game.TotalScore();
        }

        private static void AddFrame(BowlingGame game, string frame)
        {
            if (frame[0] == ScoreSymbols.StrikeToken)
            {
                game.Strike();
            }
            else
            {
                int firstThrow = frame[0] == ScoreSymbols.GutterToken ? 0 :  ParseNumericValue(frame[0]);
                if (frame[1] == ScoreSymbols.SpareToken)
                {
                    game.Spare(firstThrow, 10 - firstThrow);
                }
                else
                {
                    int secondThrow = frame[1] == ScoreSymbols.GutterToken ? 0 : ParseNumericValue(frame[1]);
                    game.OpenFrame(firstThrow, secondThrow);
                }
            }
        }

        private static void AddBonusRoll(BowlingGame game, string roll)
        {
            int numericValue = roll[0] == ScoreSymbols.StrikeToken ? 10 : ParseNumericValue(roll[0]);
            game.BonusRoll(numericValue);
        }

        private static string[] GetBonusRolls(string lastFrame)
            => lastFrame
                .Substring(lastFrame.IndexOf(ScoreSymbols.SeparatorToken) + 1)
                .Split(ScoreSymbols.SeparatorToken);

        private static int ParseNumericValue(char value)
            => (int)char.GetNumericValue(value);
    }
}