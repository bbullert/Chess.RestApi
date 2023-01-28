using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class TurnProfile : Profile
    {
        public TurnProfile()
        {
            CreateMap<Chess.RestApi.Data.Entities.Turn, Chess.RestApi.Core.Dto.Turn>();
            CreateMap<Chess.RestApi.Core.Dto.Turn, Chess.Engine.Components.Turn>();
            CreateMap<Chess.Engine.Components.Turn, Chess.RestApi.Data.Entities.Turn>();
            CreateMap<Chess.Engine.Components.Turn, Chess.RestApi.Core.Dto.Turn>();
        }
    }
}
