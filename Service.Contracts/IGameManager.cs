using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.DTOs;

namespace Service.Contracts
{
    public interface IGameManager
    {
        Task<GameDto> CreateGameAsync(int tournamentId, GameForCreationDto gameDto);
    }
}
