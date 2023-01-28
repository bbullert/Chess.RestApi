using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Chess.RestApi.Data.Entities.User, Chess.RestApi.Core.Dto.User>();
        }
    }
}
