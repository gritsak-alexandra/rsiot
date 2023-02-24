using rsiot.DataTransferObjects;
using rsiot.Models;

namespace rsiot.Contracts.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(Guid id);
        Task<User> CreateUserAsync(UserForManipulationDto userDto);
        Task AddProgramToUserAsync(Guid id, Guid programId);
        Task UpdateUserAsync(Guid id, UserForManipulationDto userDto);
        Task DeleteUserAsync(Guid id);
    }
}
