namespace Codebreaker.Data.SqlServer;

public class GamesSqlServerContext(DbContextOptions<GamesSqlServerContext> options) : DbContext(options), IGamesRepository
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("codebreaker");
        modelBuilder.ApplyConfiguration(new GameConfiguration());
        modelBuilder.ApplyConfiguration(new MoveConfiguration());
    }

    public DbSet<Game> Games => Set<Game>();
    public DbSet<Move> Moves => Set<Move>();

    public Task AddGameAsync(Game game, CancellationToken cancellationToken = default)
    {
        Games.Add(game);
        return SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteGameAsync(Guid gameId, CancellationToken cancellationToken = default)
    {
        int affected = await Games
            .Where(g => g.Id == gameId)
            .ExecuteDeleteAsync(cancellationToken);

        return affected == 1;
    }

    public Task AddMoveAsync(Game game, Move move, CancellationToken cancellationToken = default)
    {
        Moves.Add(move);
        Games.Update(game);
        return SaveChangesAsync(cancellationToken);
    }

    public async Task<Game?> GetGameAsync(Guid gameId, CancellationToken cancellationToken = default)
    {
        Game? game = await Games.Include("Moves")
        .TagWith(nameof(GetGameAsync))
        .SingleOrDefaultAsync(g => g.Id == gameId, cancellationToken);

        return game;
    }

    private const int MaxGamesReturned = 500;

    public async Task<IEnumerable<Game>> GetGamesAsync(GamesQuery gamesQuery, CancellationToken cancellationToken = default)
    {
        IQueryable<Game> query = Games
           .TagWith(nameof(GetGamesAsync))
           .Include(g => g.Moves);

        // Apply Game filters if provided.
        if (gamesQuery.Date.HasValue)
        {
            DateTime begin = gamesQuery.Date.Value.ToDateTime(TimeOnly.MinValue);
            DateTime end = begin.AddDays(1);
            query = query.Where(g => g.StartTime < end && g.StartTime > begin);
        }
        if (gamesQuery.PlayerName != null)
        {
            query = query.Where(g => g.PlayerName == gamesQuery.PlayerName);
        }
        if (gamesQuery.GameType != null)
        {
            query = query.Where(g => g.GameType == gamesQuery.GameType);
        }
        if (gamesQuery.RunningOnly)
        {
            query = query.Where(g => g.EndTime == null);
        }
        if (gamesQuery.Ended)
        {
            query = query.Where(g => g.EndTime != null)
                .OrderBy(g => g.Duration);
        }
        else
        {
            query = query.OrderByDescending(g => g.StartTime);
        }

        query = query.Take(MaxGamesReturned);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<Game> UpdateGameAsync(Game game, CancellationToken cancellationToken = default)
    {
        Games.Update(game);
        await SaveChangesAsync(cancellationToken);
        return game;
    }
}
