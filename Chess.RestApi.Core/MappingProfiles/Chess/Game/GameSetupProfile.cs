using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class GameSetupProfile : Profile
    {
        public GameSetupProfile()
        {
            CreateMap<Chess.RestApi.Data.Entities.GameSetup, Chess.RestApi.Core.Dto.GameSetup>();
            CreateMap<Chess.RestApi.Core.Dto.GameSetup, Chess.RestApi.Data.Entities.GameSetup>();
            CreateMap<Chess.RestApi.Core.Dto.GameSetup, Chess.Engine.Components.GameSetup>();
            CreateMap<Chess.Engine.Components.GameSetup, Chess.RestApi.Core.Dto.GameSetup>();
        }
    }
}
