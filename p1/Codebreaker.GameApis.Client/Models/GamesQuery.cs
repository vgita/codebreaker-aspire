using System.Text;

namespace Codebreaker.GameAPIs.Client.Models;

public record class GamesQuery(
    GameType? GameType = default,
    string? PlayerName = default,
    DateOnly? Date = default,
    bool? Ended = false)
{
    public string AsUrlQuery()
    {
        StringBuilder query = new("?");

        if (GameType != null)
        {
            query.Append($"gameType={GameType}&");
        }

        if (PlayerName != null)
        {
            query.Append($"playerName={Uri.EscapeDataString(PlayerName)}&");
        }

        if (Date != null)
        {
            string dateString = Date.Value.ToString("yyyy-MM-dd");
            query.Append($"date={dateString}&");
        }

        if (Ended != null)
        {
            query.Append($"ended={Ended}&");
        }

        // Remove the last character if it is an ampersand character
        string queryString = query.ToString().TrimEnd('&');

        return queryString;
    }
}
