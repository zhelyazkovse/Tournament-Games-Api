using Microsoft.EntityFrameworkCore;
using Tournament.Api.Data;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;

namespace Tournament.Data.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly TournamentApiContext _context;

        public TournamentRepository(TournamentApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TournamentDetails>> GetAllAsync(int page, int pageSize)
        {
            return await _context.TournamentDetails
                .Include(t => t.Games)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<TournamentDetails> GetAsync(int id)
        {
            return await _context.TournamentDetails.FindAsync(id);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context.TournamentDetails.AnyAsync(t => t.Id == id);
        }

        // Async add with SaveChanges
        public async Task AddAsync(TournamentDetails tournament)
        {
            await _context.TournamentDetails.AddAsync(tournament);
        }

        public void Update(TournamentDetails tournament)
        {
            _context.TournamentDetails.Update(tournament);
        }

        // Async delete with SaveChanges
        public async Task DeleteAsync(TournamentDetails tournament)
        {
            _context.TournamentDetails.Remove(tournament);
        }

        public async Task<TournamentDetails> GetByIdAsync(int id)
        {
            return await _context.TournamentDetails
                .Include(t => t.Games)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.TournamentDetails.AnyAsync(t => t.Id == id);
        }
        public async Task<int> CountAsync()
        {
            return await _context.TournamentDetails.CountAsync();
        }

    }
}
