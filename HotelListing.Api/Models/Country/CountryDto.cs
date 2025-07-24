using HotelListing.Api.Models.Hotel;

namespace HotelListing.Api.Models.Country 
{ 
    public class CountryDto
    {
        public int Id { get; set; }
        public String Name { get; set; } = string.Empty;
        public String ShortName { get; set; } = string.Empty;

        public List<HotelDto> Hotels { get; set; }
    }
}