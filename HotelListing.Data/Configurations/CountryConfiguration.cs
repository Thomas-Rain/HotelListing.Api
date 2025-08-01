using HotelListing.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    Id = 1,
                    Name = "United States of America",
                    ShortName = "US"
                },
                new Country
                {
                    Id = 2,
                    Name = "Dominican Republic",
                    ShortName = "DR"
                },
                new Country
                {
                    Id = 3,
                    Name = "Scotland",
                    ShortName = "SC"
                }
            );
        }
    }
}
