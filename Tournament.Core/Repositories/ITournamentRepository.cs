using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<TournamentDetails>> GetAllAsync();
        Task<TournamentDetails> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task AddAsync(TournamentDetails tournament);
        void Update(TournamentDetails tournament);
        Task DeleteAsync(TournamentDetails tournament);
    }

}
