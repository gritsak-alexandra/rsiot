using rsiot.Models;

namespace rsiot.Contracts.Repositories
{
    public interface ICoachRepository
    {
        Task<IEnumerable<Coach>> GetCoachsAsync();
        Task<Coach> GetCoachByIdAsync(Guid id);
        void CreateCoach(Coach coach);
        void UpdateCoach(Coach coach);
        void DeleteCoach(Coach coach);
    }
}
