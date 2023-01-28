using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Chess.RestApi.Data.Entities.Player, Chess.RestApi.Core.Dto.Player>()
                .ForMember(x => x.Name, act => act.MapFrom(x => x.User.UserName));
            CreateMap<Chess.RestApi.Core.Dto.Player, Chess.Engine.Components.Player>();
            CreateMap<Chess.RestApi.Core.Dto.Player, Chess.RestApi.Data.Entities.Player>();
            CreateMap<Chess.Engine.Components.Player, Chess.RestApi.Core.Dto.Player>()
                .PreserveReferences();
            CreateMap<Chess.Engine.Components.Player, Chess.RestApi.Data.Entities.Player>();
        }
    }
}
