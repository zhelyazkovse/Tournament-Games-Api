using AutoMapper;
using SendGrid.Helpers.Errors.Model;
using Service.Contracts;
using Tournament.Core.DTOs;
using Tournament.Core.Repositories;
using Volo.Abp;
using Tournament.Core.Entities;

namespace Tournament.Services
{
    public class GameManager : IGameManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GameDto> CreateGameAsync(int tournamentId, GameForCreationDto gameDto)
        {
            var tournament = await _unitOfWork.TournamentRepository.GetByIdAsync(tournamentId);
            if (tournament == null)
                throw new NotFoundException($"Tournament {tournamentId} not found.");

            if (tournament.Games.Count >= 10)
                throw new BusinessException("A tournament can have a maximum of 10 games.");

            var game = _mapper.Map<Game>(gameDto);
            tournament.Games.Add(game);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<GameDto>(game);
        }
    }
}
