# Bowling Game

**Problem:** Calculate game final score

Kata: [codingdojo.org/kata/Bowling](https://codingdojo.org/kata/Bowling/)

### How To Run

#### Using Numeric Values

```csharp
var game = new BowlingGame();
game.OpenFrame(2, 7); // Some pins missed
game.Spare(4, 6);     // All pins down in 2 attempts
game.Strike();        // All pins down in first attempt
game.BonusRoll(3);    // Bonus roll after last frame
int totalScore = game.TotalScore();
```

#### Using String Values

```csharp
int totalScore = GameParser.Parse("x 4- 6/ x 21 8- 72 -- 44 5/ 5");
int totalScore = GameParser.Parse("x x x x x x x x x x x x");
int totalScore = GameParser.Parse("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5");
```

Any bonus rolls must be included at the end.