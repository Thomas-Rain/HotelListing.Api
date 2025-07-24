using AutoMapper;
using HotelListing.Api.Data;
using HotelListing.Api.Models.Country;
using HotelListing.Api.Models.Hotel;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Country, CountryDto>().ReverseMap();
        CreateMap<Country, GetCountryDto>().ReverseMap();
        CreateMap<Country, CreateCountryDto>().ReverseMap();
        CreateMap<Hotel, HotelDto>().ReverseMap();
    }
}
