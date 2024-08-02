namespace Codebreaker.GameAPIs.Models.Extensions;

public static class GameExtensions
{
    public static bool HasEnded(this Game game) => game.EndTime is not null;
}
