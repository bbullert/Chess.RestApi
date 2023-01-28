using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class CastleProfile : Profile
    {
        public CastleProfile()
        {
            CreateMap<Chess.RestApi.Core.Dto.Castle, Chess.Engine.Components.Castle>();
            CreateMap<Chess.Engine.Components.Castle, Chess.RestApi.Core.Dto.Castle>()
                .ForMember(x => x.DepartureSquareName, act => act.MapFrom(x => x.DepartureSquare.ToString()))
                .ForMember(x => x.ArrivalSquareName, act => act.MapFrom(x => x.ArrivalSquare.ToString()));
            CreateMap<Chess.Engine.Components.Castle, Chess.RestApi.Data.Entities.Castle>()
                .ForMember(x => x.DepartureSquareName, act => act.MapFrom(x => x.DepartureSquare.ToString()))
                .ForMember(x => x.ArrivalSquareName, act => act.MapFrom(x => x.ArrivalSquare.ToString()));
            CreateMap<Chess.RestApi.Data.Entities.Castle, Chess.RestApi.Core.Dto.Castle>();
        }
    }
}
