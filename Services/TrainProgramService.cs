using AutoMapper;
using rsiot.Contracts.Repositories;
using rsiot.Contracts.Services;
using rsiot.DataTransferObjects;
using rsiot.Exceptions;
using rsiot.Models;

namespace rsiot.Services
{
    public class TrainProgramService : ITrainProgramService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public TrainProgramService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<TrainProgram> CreateTrainProgramAsync(Guid coachId, TrainProgramForManipulationDto trainProgramDto)
        {
            var coach = await _repositoryManager.CoachRepository.GetCoachByIdAsync(coachId);
            if (coach == null)
                throw new NotFoundException("coach not found");

            var trainProgram = _mapper.Map<TrainProgram>(trainProgramDto);

            _repositoryManager.TrainProgramRepository.CreateTrainProgram(coachId, trainProgram);
            await _repositoryManager.SaveChangesAsync();

            return trainProgram;
        }

        public async Task DeleteTrainProgramAsync(Guid coachId, Guid id)
        {
            var coach = await _repositoryManager.CoachRepository.GetCoachByIdAsync(coachId);
            if (coach == null)
                throw new NotFoundException("coach not found");

            var trainProgram = await _repositoryManager.TrainProgramRepository.GetTrainProgramByIdAsync(coachId, id);
            if (trainProgram == null)
                throw new NotFoundException("trainProgram not found");

            _repositoryManager.TrainProgramRepository.DeleteTrainProgram(trainProgram);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task<TrainProgram> GetTrainProgramAsync(Guid coachId, Guid id)
        {
            var coach = await _repositoryManager.CoachRepository.GetCoachByIdAsync(coachId);
            if (coach == null)
                throw new NotFoundException("coach not found");

            var trainProgram = await _repositoryManager.TrainProgramRepository.GetTrainProgramByIdAsync(coachId, id);
            if (trainProgram == null)
                throw new NotFoundException("trainProgram not found");

            return trainProgram;
        }

        public async Task<IEnumerable<TrainProgram>> GetTrainProgramsAsync() =>
            await _repositoryManager.TrainProgramRepository.GetTrainProgramsAsync();

        public async Task UpdateTrainProgramAsync(Guid coachId, Guid id, TrainProgramForManipulationDto trainProgramDto)
        {
            var coach = await _repositoryManager.CoachRepository.GetCoachByIdAsync(coachId);
            if (coach == null)
                throw new NotFoundException("coach not found");

            var trainProgram = await _repositoryManager.TrainProgramRepository.GetTrainProgramByIdAsync(coachId, id);
            if (trainProgram == null)
                throw new NotFoundException("trainProgram not found");

            _mapper.Map(trainProgramDto, trainProgram);

            _repositoryManager.TrainProgramRepository.UpdateTrainProgram(trainProgram);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
