﻿
namespace Tournament.Core.Repositories
{
    public interface IUnitOfWork
    {
        ITournamentRepository TournamentRepository { get; }
        IGameRepository GameRepository { get; }
        IPlayerRepository PlayerRepository { get; }

        Task CompleteAsync();
    }
}
