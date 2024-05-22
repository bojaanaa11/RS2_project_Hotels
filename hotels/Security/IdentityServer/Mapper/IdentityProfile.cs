using AutoMapper;
using IdentityServer.DTOs;
using IdentityServer.Entities;

namespace IdentityServer.Mapper
{
    public class IdentityProfile : Profile
    {
        protected IdentityProfile()
        {
            CreateMap<User, NewUserDto>().ReverseMap();
        }
    }
}
