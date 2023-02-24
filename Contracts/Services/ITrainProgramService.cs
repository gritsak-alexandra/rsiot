using rsiot.DataTransferObjects;
using rsiot.Models;

namespace rsiot.Contracts.Services
{
    public interface ITrainProgramService
    {
        Task<IEnumerable<TrainProgram>> GetTrainProgramsAsync();
        Task<TrainProgram> GetTrainProgramAsync(Guid coachId, Guid id);
        Task<TrainProgram> CreateTrainProgramAsync(Guid coachId, TrainProgramForManipulationDto trainProgramDto);
        Task UpdateTrainProgramAsync(Guid coachId, Guid id, TrainProgramForManipulationDto trainProgramDto);
        Task DeleteTrainProgramAsync(Guid coachId, Guid id);
    }
}
