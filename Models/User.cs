namespace rsiot.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<TrainProgram> TrainPrograms { get; set; }
    }
}
