using System.ComponentModel.DataAnnotations;

namespace HotelListing.Api.Models.Country
{
    public abstract class BaseCountryDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
    }
}
