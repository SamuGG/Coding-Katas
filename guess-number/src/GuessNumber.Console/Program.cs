using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
        bool playAgain;

        Console.Write("Before start playing, please enter your name to keep your scores: ");
        string? playerName = Console.ReadLine();

        if (!File.Exists("high-scores.txt"))
            File.Create("high-scores.txt");

        do
        {
            Console.WriteLine($"All right {playerName}, let's play...");
            Score score = Play();
            SaveHighScore(score, playerName);
            Console.WriteLine();
            Console.Write("Would you like to play again? [Y]es, [N]o: ");
            string? input = Console.ReadLine();
            playAgain = input?.ToLower() == "y";
        } while (playAgain);

        IReadOnlyCollection<HighScore> highScores = LoadHighScores();
        if (highScores.Any())
        {
            Console.WriteLine("High Scores");
            foreach(HighScore highScore in highScores)
                Console.WriteLine($"{highScore.PlayerName} - {highScore.Time} - {highScore.Points}");
        }
    }

    public enum GuessRange
    {
        Lower,
        Higher
    }

    private sealed record Score(TimeSpan Time, int Points);
    private sealed record HighScore(string PlayerName, TimeSpan Time, int Points);

    private static Score Play()
    {
        int currentNumber = Random.Shared.Next(1, 101);
        int nextNumber;
        var timer = new Stopwatch();
        var score = new Score(TimeSpan.Zero, 0);

        do
        {
            nextNumber = Random.Shared.Next(1, 101);

            while (nextNumber == currentNumber)
                nextNumber = Random.Shared.Next(1, 101);

            Console.Write($"Will next number be [h]igher or [l]ower than {currentNumber}? ");
            timer.Restart();
            string? input = Console.ReadLine();
            timer.Stop();

            GuessRange guess = input?.ToLower() switch
            {
                "h" => GuessRange.Higher,
                "l" => GuessRange.Lower,
                _ => GuessRange.Lower
            };

            if ((guess == GuessRange.Higher && currentNumber < nextNumber)
                || (guess == GuessRange.Lower && nextNumber < currentNumber))
                score = new Score(score.Time + timer.Elapsed, score.Points + 1);
            else
            {
                score = new Score(score.Time + timer.Elapsed, score.Points);
                break;
            }

            currentNumber = nextNumber;
        } while(score.Points < 10);

        if (score.Points >= 10)
            Console.WriteLine("Congratulations you won!");
        else
            Console.WriteLine($"The number was {nextNumber}, sorry");

        Console.WriteLine();
        Console.WriteLine($"You scored {score.Points} points and you played for {score.Time}.");

        return score;
    }

    private static void SaveHighScore(Score score, string playerName)
    {
        var newHighScore = new HighScore(playerName, score.Time, score.Points);

        List<HighScore> highScores = LoadHighScores()
            .Append(newHighScore)
            .OrderByDescending(s => s.Points)
            .ThenByDescending(s => s.Time)
            .Take(3)
            .ToList();

        using var writer = new StreamWriter("high-scores.txt", false);
        foreach (var highScore in highScores)
            writer.WriteLine($"{playerName},{highScore.Time},{highScore.Points}");
    }

    private static IReadOnlyCollection<HighScore> LoadHighScores()
    {
        using var reader = new StreamReader("high-scores.txt");
        string[] lines = reader.ReadToEnd().Split(Environment.NewLine);

        return lines
            .Select(l => l.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .TakeWhile(l => l.Any())
            .Select(s => new HighScore(s[0], TimeSpan.Parse(s[1]), int.Parse(s[2])))
            .OrderByDescending(s => s.Points)
            .ThenByDescending(s => s.Time)
            .ToList();
    }
}