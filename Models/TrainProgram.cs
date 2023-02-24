namespace rsiot.Models
{
    public class TrainProgram
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CoachId { get; set; }

        public Coach Coach { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
