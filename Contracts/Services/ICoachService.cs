using rsiot.DataTransferObjects;
using rsiot.Models;

namespace rsiot.Contracts.Services
{
    public interface ICoachService
    {
        Task<IEnumerable<Coach>> GetCoachsAsync();
        Task<Coach> GetCoachAsync(Guid id);
        Task<Coach> CreateCoachAsync(CoachForManipulationDto coachDto);
        Task UpdateCoachAsync(Guid id, CoachForManipulationDto coachDto);
        Task DeleteCoachAsync(Guid id);
    }
}