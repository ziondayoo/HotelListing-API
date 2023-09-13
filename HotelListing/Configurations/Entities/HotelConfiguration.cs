using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData
             (
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
