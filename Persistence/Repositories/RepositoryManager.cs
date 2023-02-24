using rsiot.Contracts.Repositories;

namespace rsiot.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private AppDbContext _context;
        private IUserRepository _userRepository;
        private ICoachRepository _coachRepository;
        private ITrainProgramRepository _trainProgramRepository;

        public RepositoryManager(AppDbContext context)
        {
            _context = context;
        }

        public ICoachRepository CoachRepository
        {
            get
            {
                if (_coachRepository == null)
                    _coachRepository = new CoachRepository(_context);
                return _coachRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public ITrainProgramRepository TrainProgramRepository
        {
            get
            {
                if (_trainProgramRepository == null)
                    _trainProgramRepository = new TrainProgramRepository(_context);
                return _trainProgramRepository;
            }
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
