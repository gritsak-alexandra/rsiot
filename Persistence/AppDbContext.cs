using Microsoft.EntityFrameworkCore;
using rsiot.Models;

namespace rsiot.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<TrainProgram> TrainPrograms { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(u => u.TrainPrograms)
                .WithMany(p => p.Users);

            builder.Entity<Coach>()
                .HasMany(c => c.TrainPrograms)
                .WithOne(p => p.Coach)
                .HasForeignKey(p => p.CoachId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
