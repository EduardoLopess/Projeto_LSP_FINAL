using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace api.Configuration
{
    public class AutoMapperConfigDTOs : Profile
    {
        public AutoMapperConfigDTOs()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.FullName, map => map.MapFrom(src => $"{src.Name} {src.Surname}"))
                .ForMember(dest => dest.AddressesDTO, map => map.MapFrom(src => src.Addresses));
            
            CreateMap<Address, AddressDTO>()
                .ForMember(dest => dest.UserId, map => map.MapFrom(src => src.UserId));
        
        }
    }
}