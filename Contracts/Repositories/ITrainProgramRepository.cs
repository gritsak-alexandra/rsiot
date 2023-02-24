using rsiot.Models;

namespace rsiot.Contracts.Repositories
{
    public interface ITrainProgramRepository
    {
        Task<IEnumerable<TrainProgram>> GetTrainProgramsAsync();
        Task<TrainProgram> GetTrainProgramByIdAsync(Guid coachId, Guid id);
        Task<TrainProgram> GetTrainProgramByIdAsync(Guid id);
        void CreateTrainProgram(Guid coachId, TrainProgram trainProgram);
        void UpdateTrainProgram(TrainProgram trainProgram);
        void DeleteTrainProgram(TrainProgram trainProgram);
    }
}
