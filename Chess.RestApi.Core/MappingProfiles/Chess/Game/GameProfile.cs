using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Chess.RestApi.Data.Entities.Game, Chess.RestApi.Core.Dto.Game>();
            CreateMap<Chess.RestApi.Core.Dto.Game, Chess.Engine.Components.Game>();
            CreateMap<Chess.Engine.Components.Game, Chess.RestApi.Data.Entities.Game>();
        }
    }
}
