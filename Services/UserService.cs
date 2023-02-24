using AutoMapper;
using rsiot.Contracts.Repositories;
using rsiot.Contracts.Services;
using rsiot.DataTransferObjects;
using rsiot.Exceptions;
using rsiot.Models;

namespace rsiot.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<User> CreateUserAsync(UserForManipulationDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _repositoryManager.UserRepository.CreateUser(user);
            await _repositoryManager.SaveChangesAsync();

            return user;
        }

        public async Task AddProgramToUserAsync(Guid id, Guid programId)
        {
            var user = await _repositoryManager.UserRepository.GetUserByIdAsync(id);
            if (user == null)
                throw new NotFoundException("user not found");

            var trainProgram = await _repositoryManager.TrainProgramRepository.GetTrainProgramByIdAsync(programId);
            if (trainProgram == null)
                throw new NotFoundException("train program not found");

            user.TrainPrograms.Add(trainProgram);
            _repositoryManager.UserRepository.UpdateUser(user);

            await _repositoryManager.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _repositoryManager.UserRepository.GetUserByIdAsync(id);
            if (user == null)
                throw new NotFoundException("user not found");
            _repositoryManager.UserRepository.DeleteUser(user);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var user = await _repositoryManager.UserRepository.GetUserByIdAsync(id);
            if(user == null)
                throw new NotFoundException("user not found");
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync() =>
            await _repositoryManager.UserRepository.GetUsersAsync();

        public async Task UpdateUserAsync(Guid id, UserForManipulationDto userDto)
        {
            var user = await _repositoryManager.UserRepository.GetUserByIdAsync(id);
            if (user == null)
                throw new NotFoundException("user not found");

            _mapper.Map(userDto, user);

            _repositoryManager.UserRepository.UpdateUser(user);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
