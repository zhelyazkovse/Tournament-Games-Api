using Microsoft.EntityFrameworkCore;
using Tournament.Api.Data;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournament.Data.Data;

namespace Tournament.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly TournamentApiContext _context;

        public PlayerRepository(TournamentApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetAllAsync() =>
            await _context.Players.ToListAsync();

        public async Task<Player?> GetAsync(int id) =>
            await _context.Players.FindAsync(id);

        public async Task AddAsync(Player player) =>
            await _context.Players.AddAsync(player);

        public void Update(Player player) =>
            _context.Players.Update(player);

        public async Task DeleteAsync(Player player) =>
            await Task.Run(() => _context.Players.Remove(player));

        public async Task<bool> ExistsAsync(int id) =>
            await _context.Players.AnyAsync(p => p.Id == id);
    }
}