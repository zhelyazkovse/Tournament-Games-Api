using AutoMapper;
using Service.Contracts;
using Tournament.Core.DTOs;
using Tournament.Core.Repositories;

namespace Tournament.Services
{
    public class TournamentManager : ITournamentManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TournamentManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<TournamentDto> Tournaments, PaginationMetadata Metadata)> GetAllAsync(int page, int pageSize)
        {
            pageSize = Math.Min(pageSize <= 0 ? 20 : pageSize, 100);
            var totalItems = await _unitOfWork.TournamentRepository.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var tournaments = await _unitOfWork.TournamentRepository.GetAllAsync(page, pageSize);
            var tournamentDtos = _mapper.Map<IEnumerable<TournamentDto>>(tournaments);

            var metadata = new PaginationMetadata {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize
            };

            return (tournamentDtos, metadata);
        }
    }
}
