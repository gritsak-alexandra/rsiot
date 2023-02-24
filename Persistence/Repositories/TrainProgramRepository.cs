using Microsoft.EntityFrameworkCore;
using rsiot.Contracts.Repositories;
using rsiot.Models;

namespace rsiot.Persistence.Repositories
{
    public class TrainProgramRepository : RepositoryBase<TrainProgram>, ITrainProgramRepository
    {
        public TrainProgramRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateTrainProgram(Guid coachId, TrainProgram trainProgram)
        {
            trainProgram.CoachId = coachId;
            Create(trainProgram);
        }

        public void DeleteTrainProgram(TrainProgram trainProgram) =>
            Delete(trainProgram);

        public async Task<IEnumerable<TrainProgram>> GetTrainProgramsAsync() =>
            await GetAll().ToListAsync();

        public async Task<TrainProgram> GetTrainProgramByIdAsync(Guid coachId, Guid id) =>
            await GetByCondition(a => a.CoachId == coachId && a.Id == id)
            .SingleOrDefaultAsync();

        public async Task<TrainProgram> GetTrainProgramByIdAsync(Guid id) =>
            await GetByCondition(a => a.Id == id)
            .SingleOrDefaultAsync();

        public void UpdateTrainProgram(TrainProgram trainProgram) =>
            Update(trainProgram);
    }
}
