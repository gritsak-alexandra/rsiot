using Microsoft.EntityFrameworkCore;
using rsiot.Contracts.Repositories;
using rsiot.Models;

namespace rsiot.Persistence.Repositories
{
    public class CoachRepository : RepositoryBase<Coach>, ICoachRepository
    {
        public CoachRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateCoach(Coach coach) =>
            Create(coach);

        public void DeleteCoach(Coach coach) =>
            Delete(coach);

        public async Task<Coach> GetCoachByIdAsync(Guid id) =>
            await GetByCondition(d => d.Id == id).SingleOrDefaultAsync();

        public async Task<IEnumerable<Coach>> GetCoachsAsync() =>
            await GetAll().ToListAsync();

        public void UpdateCoach(Coach coach) =>
            Update(coach);
    }
}
