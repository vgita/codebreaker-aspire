using System.Collections;

using static Codebreaker.GameAPIs.Models.Colors;

namespace Codebreaker.Analyzers.Tests.Analyzers;

public class ColorGame6x4AnalyzerTests
{
  private static MockColorGame CreateGame(string[] codes) => new()
  {
    GameType = GameTypes.Game6x4,
    NumberCodes = 4,
    MaxMoves = 12,
    IsVictory = false,
    FieldValues = new Dictionary<string, IEnumerable<string>>()
    {
      [FieldCategories.Colors] = [.. TestData6x4.Colors6]
    },
    Codes = codes
  };

  private static ColorResult AnalyzeGame(string[] codes, string[] guesses, int moveNumber = 1)
  {
    MockColorGame game = CreateGame(codes);
    ColorGameGuessAnalyzer analyzer = new(game, [.. guesses.ToPegs<ColorField>()], moveNumber);
    return analyzer.GetResult();
  }

  private static IGame AnalyzeGameCatchingException(string[] codes, string[] guesses, int moveNumber = 1)
  {
    MockColorGame game = CreateGame(codes);
    ColorGameGuessAnalyzer analyzer = new(game, [.. guesses.ToPegs<ColorField>()], moveNumber);
    try
    {
      analyzer.GetResult();
    }
    catch (ArgumentException)  // catch ArgumentException to allow checking for the game move number not changed
    {
    }
    return game;
  }
}

public class TestData6x4 : IEnumerable<object[]>
{
  public static readonly string[] Colors6 = [Red, Green, Blue, Yellow, Black, White];

  public IEnumerator<object[]> GetEnumerator()
  {
    yield return new object[]
    {
            new string[] { Green, Blue,  Green, Yellow }, // code
            new string[] { Green, Green, Black, White },  // input-data
            new ColorResult(1, 1) // expected
    };
    yield return new object[]
    {
            new string[] { Red,   Blue,  Black, White },
            new string[] { Black, Black, Red,   Yellow },
            new ColorResult(0, 2)
    };
    yield return new object[]
    {
            new string[] { Yellow, Black, Yellow, Green },
            new string[] { Black,  Black, Black,  Black },
            new ColorResult(1, 0)
    };
    yield return new object[]
    {
            new string[] { Yellow, Yellow, White, Red },
            new string[] { Green,  Yellow, White, Red },
            new ColorResult(3, 0)
    };
    yield return new object[]
    {
            new string[] { White, Black, Yellow, Black },
            new string[] { Black, Blue,  Black,  White },
            new ColorResult(0, 3)
    };
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

