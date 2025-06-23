using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game> GetAsync(int id);
        Task AddAsync(Game game);            
        Task DeleteAsync(Game game);  
        void Update(Game game);
        Task<bool> AnyAsync(int id);
    }
}
