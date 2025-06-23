using Microsoft.EntityFrameworkCore;

namespace Tournament.Api.Data
{
    public class TournamentApiContext : DbContext
    {
        public TournamentApiContext (DbContextOptions<TournamentApiContext> options)
            : base(options)
        {
        }

        public DbSet<Tournament.Core.Entities.TournamentDetails> TournamentDetails { get; set; } = default!;
        public DbSet<Tournament.Core.Entities.Game> Game { get; set; } = default!;
    }
}
