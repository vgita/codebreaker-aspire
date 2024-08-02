namespace Codebreaker.GameAPIs.Services;

public class GamesService(IGamesRepository gamesRepository) : IGamesService
{
    public async Task<Game> StartGameAsync(string gameType, string playerName, CancellationToken cancellationToken = default)
    {
        Game game = GamesFactory.CreateGame(gameType, playerName);

        await gamesRepository.AddGameAsync(game, cancellationToken);
        return game;
    }

    public async Task<(Game Game, Move Move)> SetMoveAsync(Guid id, string[] guesses, int moveNumber, CancellationToken cancellationToken = default)
    {
        Game? game = await gamesRepository.GetGameAsync(id, cancellationToken);
        CodebreakerException.ThrowIfNull(game);
        CodebreakerException.ThrowIfEnded(game);

        Move move = game.ApplyMove(guesses, moveNumber);

        // Update the game in the game-service database
        await gamesRepository.AddMoveAsync(game, move, cancellationToken);

        return (game, move);
    }

    // get the game from the cache or the data repository
    public async ValueTask<Game?> GetGameAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var game = await gamesRepository.GetGameAsync(id, cancellationToken);
        return game;
    }

    public async Task DeleteGameAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await gamesRepository.DeleteGameAsync(id, cancellationToken);
    }

    public async Task<Game> EndGameAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Game? game = await gamesRepository.GetGameAsync(id, cancellationToken);
        CodebreakerException.ThrowIfNull(game);

        game.EndTime = DateTime.Now;
        game.Duration = game.EndTime - game.StartTime;
        game = await gamesRepository.UpdateGameAsync(game, cancellationToken);
        return game;
    }

    public async Task<IEnumerable<Game>> GetGamesAsync(GamesQuery gamesQuery, CancellationToken cancellationToken = default)
    {
        return await gamesRepository.GetGamesAsync(gamesQuery, cancellationToken);
    }
}
