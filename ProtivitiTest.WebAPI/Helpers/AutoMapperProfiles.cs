using AutoMapper;
using ProtivitiTest.WebAPI.DTOs;
using ProtivitiTest.WebAPI.Models;

#nullable disable
namespace ProtivitiTest.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            //one way
            CreateMap<CustomerDto, Customer>();

            //reverse mapping
            CreateMap<Customer, CustomerDto>();
        }
    }
}