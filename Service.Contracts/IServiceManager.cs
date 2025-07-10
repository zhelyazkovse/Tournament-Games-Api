using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Contracts;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        ITournamentManager TournamentManager { get; }
        IGameManager GameManager { get; }
    }
}
