﻿using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configurations.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData
            (
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
        }
    }
}
