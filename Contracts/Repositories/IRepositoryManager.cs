namespace rsiot.Contracts.Repositories
{
    public interface IRepositoryManager
    {
        ICoachRepository CoachRepository { get; }
        IUserRepository UserRepository { get; }
        ITrainProgramRepository TrainProgramRepository { get; }
        Task SaveChangesAsync();
    }
}
