using AutoMapper;
using Trainer.Common.DTO.Auth;
using Trainer.Common.DTO.UserDTO;
using Trainer.Domain.Enums;
using Trainer.Domain.Models;

namespace Trainer.Common.MappingProfiles
{
    public sealed class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>().ReverseMap();

            CreateMap<User, UserLoginDTO>()
                .ForMember(p => p.AccessToken, opt => opt.Ignore());

            CreateMap<UserLoginDTO, User>()
                .ForMember(p => p.Role, opt => opt.MapFrom(c => Role.User))
                .ForMember(p => p.Tracks, opt => opt.Ignore());
        }
    }
}
