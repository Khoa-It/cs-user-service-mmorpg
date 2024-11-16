using _3D_WebGame.DTOs.User;
using _3D_WebGame.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace _3D_WebGame.Configurations {
    public class GameMappingProfile : Profile {
        public GameMappingProfile()
        {
            CreateMap<UserUpdateDto, User>();
            CreateMap<AccountDto, User>();
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserGetDto>();
        }
    }
}
