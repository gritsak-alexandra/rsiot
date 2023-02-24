using AutoMapper;
using rsiot.Contracts.Repositories;
using rsiot.Contracts.Services;
using rsiot.DataTransferObjects;
using rsiot.Exceptions;
using rsiot.Models;

namespace rsiot.Services
{
    public class CoachService : ICoachService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CoachService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Coach> CreateCoachAsync(CoachForManipulationDto coachDto)
        {
            var coach = _mapper.Map<Coach>(coachDto);

            _repositoryManager.CoachRepository.CreateCoach(coach);
            await _repositoryManager.SaveChangesAsync();

            return coach;
        }

        public async Task DeleteCoachAsync(Guid id)
        {
            var coach = await _repositoryManager.CoachRepository.GetCoachByIdAsync(id);
            if (coach == null)
                throw new NotFoundException("coach not found");

            _repositoryManager.CoachRepository.DeleteCoach(coach);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task<Coach> GetCoachAsync(Guid id)
        {
            var coach = await _repositoryManager.CoachRepository.GetCoachByIdAsync(id);
            if (coach == null)
                throw new NotFoundException("coach not found");

            return coach;
        }

        public async Task<IEnumerable<Coach>> GetCoachsAsync() =>
            await _repositoryManager.CoachRepository.GetCoachsAsync();

        public async Task UpdateCoachAsync(Guid id, CoachForManipulationDto coachDto)
        {
            var coach = await _repositoryManager.CoachRepository.GetCoachByIdAsync(id);
            if (coach == null)
                throw new NotFoundException("coach not found");

            _mapper.Map(coachDto, coach);

            _repositoryManager.CoachRepository.UpdateCoach(coach);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
