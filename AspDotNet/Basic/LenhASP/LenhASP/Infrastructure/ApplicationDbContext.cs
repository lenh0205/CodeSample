using LenhASP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LenhASP.Infrastructure
{
    public partial class ApplicationDbContext : DbContext
    {

        private readonly IConfiguration _configuration;
        public ApplicationDbContext(IConfiguration configuration) => _configuration = configuration;

        public ApplicationDbContext(IConfiguration configuration, DbContextOptions<ApplicationDbContext> options)
        : base(options) => _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
            //        x => x.UseNetTopologySuite());
            //}
        }

        public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public virtual DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
