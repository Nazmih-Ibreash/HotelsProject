using Hotels.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hotels.Data
{
    public class HotelContext : DbContext
    {
        private readonly IConfiguration _config;
        public HotelContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Place> Hotels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:HotelContextDb"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
//@"Server=(localdb)\mssqllocaldb;Database=Test"
