using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Api.Models.Country
{
    public class GetCountryDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String ShortName { get; set; }
    }
}
