using Microsoft.EntityFrameworkCore;
using rsiot.Contracts.Repositories;
using rsiot.Contracts.Services;
using rsiot.Persistence;
using rsiot.Persistence.Repositories;
using rsiot.Services;

namespace rsiot.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<ITrainProgramService, TrainProgramService>();
            services.AddScoped<ICoachService, CoachService>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void ConfigurePostgresConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts =>
             opts.UseNpgsql(configuration.GetConnectionString("postgreConnection")));
        }

        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(opts =>
            {
                opts.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
    }
}
