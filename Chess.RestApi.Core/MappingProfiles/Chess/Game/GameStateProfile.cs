using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class GameStateProfile : Profile
    {
        public GameStateProfile()
        {
            CreateMap<Chess.RestApi.Data.Entities.GameState, Chess.RestApi.Core.Dto.GameState>();
            CreateMap<Chess.RestApi.Core.Dto.GameState, Chess.Engine.Components.GameState>();
            CreateMap<Chess.Engine.Components.GameState, Chess.RestApi.Data.Entities.GameState>();
            CreateMap<Chess.Engine.Components.GameState, Chess.RestApi.Core.Dto.GameState>();
        }
    }
}
