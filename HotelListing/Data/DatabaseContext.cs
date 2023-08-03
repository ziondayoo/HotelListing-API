using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Nigeria",
                    ShortName = "NG",
                },
                new Country
                {
                    Id = 2,
                    Name = "Sao Tome",
                    ShortName = "ST",
                },
                new Country
                {
                    Id = 3,
                    Name = "Togo",
                    ShortName = "TG"
                }
            );
            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Ilaje Resort",
                    Address = "Iworoad Ibadan",
                    CountryId = 1,
                    Rating = 4.7
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Pestana Mira",
                    Address = "Sao Tome",
                    CountryId = 2,
                    Rating = 4
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Ibis Lome",
                    Address = "Lome Togo",
                    CountryId = 3,
                    Rating = 4.1
                }
            );
        }
    }
}
