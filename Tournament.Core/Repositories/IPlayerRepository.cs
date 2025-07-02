using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllAsync();
        Task<Player?> GetAsync(int id);
        Task AddAsync(Player player);
        void Update(Player player);
        Task DeleteAsync(Player player);
        Task<bool> ExistsAsync(int id);
    }
}
