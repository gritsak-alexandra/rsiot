using Microsoft.EntityFrameworkCore;
using rsiot.Contracts.Repositories;
using rsiot.Models;

namespace rsiot.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public void CreateUser(User user) =>
            Create(user);

        public void DeleteUser(User user) =>
            Delete(user);

        public async Task<User> GetUserByIdAsync(Guid id) =>
            await GetByCondition(p => p.Id == id)
            .Include(u => u.TrainPrograms)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<User>> GetUsersAsync() =>
            await GetAll().ToListAsync();

        public void UpdateUser(User user) =>
            Update(user);
    }
}
