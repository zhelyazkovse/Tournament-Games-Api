using Microsoft.EntityFrameworkCore;
using Tournament.Api.Data;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;

namespace Tournament.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly TournamentApiContext _context;

        public GameRepository(TournamentApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Game.ToListAsync();
        }

        public async Task<Game> GetAsync(int id)
        {
            return await _context.Game.FindAsync(id);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context.Game.AnyAsync(g => g.Id == id);
        }

        // Implement async AddAsync and save changes immediately
        public async Task AddAsync(Game game)
        {
            await _context.Game.AddAsync(game);
        }

        // Keep synchronous update (only changes tracking)
        public void Update(Game game)
        {
            _context.Game.Update(game);
        }

        // Implement async DeleteAsync and save changes immediately
        public async Task DeleteAsync(Game game)
        {
            _context.Game.Remove(game);
        }
    }
}
