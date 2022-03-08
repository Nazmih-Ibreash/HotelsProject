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
        public DbSet<Hotel> Hotels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:HotelContextDb"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var hotels = modelBuilder.Entity<Hotel>();
            hotels.Property(h => h.City).HasColumnType("varchar(15)").IsRequired();
            hotels.Property(h => h.Title).HasColumnType("varchar(40)").IsRequired();
            hotels.Property(h => h.Description).HasColumnType("varchar(400)").IsRequired();
            hotels.Property(h => h.Img).HasColumnType("varchar(50)").IsRequired();
            hotels.Property(h => h.Stars).IsRequired();
        }
    }
}
