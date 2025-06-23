using Tournament.Api.Data;
using Tournament.Core.Repositories;

namespace Tournament.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TournamentApiContext _context;

        public ITournamentRepository TournamentRepository { get; }
        public IGameRepository GameRepository { get; }

        public UnitOfWork(TournamentApiContext context)
        {
            _context = context;
            TournamentRepository = new TournamentRepository(_context);
            GameRepository = new GameRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
