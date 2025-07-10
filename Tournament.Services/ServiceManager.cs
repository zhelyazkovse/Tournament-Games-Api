using AutoMapper;
using Service.Contracts;
using Tournament.Core.Repositories;


namespace Tournament.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITournamentManager> _tournamentManager;
        private readonly Lazy<IGameManager> _gameManager;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _tournamentManager = new Lazy<ITournamentManager>(() =>
                new TournamentManager(unitOfWork, mapper));

            _gameManager = new Lazy<IGameManager>(() =>
                new GameManager(unitOfWork, mapper));
        }

        public ITournamentManager TournamentManager => _tournamentManager.Value;
        public IGameManager GameManager => _gameManager.Value;
    }
}
