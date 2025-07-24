using System.ComponentModel.DataAnnotations;

namespace HotelListing.Api.Models.Country
{
    public class CreateCountryDto
    {
        [Required]
        public String Name { get; set; } = string.Empty;
        public String ShortName { get; set; } = string.Empty;

    }
}
