using HotelListing.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Hotel California",
                    Address = "A House, New Orleans, NO",
                    CountryId = 1,
                    Rating = 4.5,
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Heartbreak Hotel",
                    Address = "123 Sunset Blvd, Los Angeles, CA",
                    CountryId = 1,
                    Rating = 3.2,
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Fawlty Towers",
                    Address = "123 Main St, Torquay, UK",
                    CountryId = 3,
                    Rating = 0.2,
                }
            );
        }
    }
}
