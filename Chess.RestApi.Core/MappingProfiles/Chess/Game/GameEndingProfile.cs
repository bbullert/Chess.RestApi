using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class GameEndingProfile : Profile
    {
        public GameEndingProfile()
        {
            CreateMap<Chess.RestApi.Data.Entities.GameEnding, Chess.RestApi.Core.Dto.GameEnding>();
            CreateMap<Chess.RestApi.Core.Dto.GameEnding, Chess.Engine.Components.GameEnding>();
            CreateMap<Chess.Engine.Components.GameEnding, Chess.RestApi.Core.Dto.GameEnding>();
            CreateMap<Chess.RestApi.Core.Dto.GameEnding, Chess.RestApi.Data.Entities.GameEnding>();
            CreateMap<Chess.Engine.Components.GameEnding, Chess.RestApi.Data.Entities.GameEnding>();
        }
    }
}
