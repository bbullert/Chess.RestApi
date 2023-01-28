using AutoMapper;
using Chess.Engine.Extensions;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class MoveProfile : Profile
    {
        public MoveProfile()
        {
            CreateMap<Chess.Engine.Components.Move, Chess.RestApi.Core.Dto.Move>()
                .ForMember(x => x.DepartureSquareName, act => act.MapFrom(x => x.DepartureSquare.ToString()))
                .ForMember(x => x.ArrivalSquareName, act => act.MapFrom(x => x.ArrivalSquare.ToString()))
                .ForMember(x => x.Description, act => act.MapFrom(x => x.ToString()))
                .PreserveReferences();

            CreateMap<Chess.Engine.Components.Move, Chess.RestApi.Data.Entities.Move>()
                .ForMember(x => x.DepartureSquareName, act => act.MapFrom(x => x.DepartureSquare.ToString()))
                .ForMember(x => x.ArrivalSquareName, act => act.MapFrom(x => x.ArrivalSquare.ToString()))
                .PreserveReferences();

            CreateMap<Chess.RestApi.Core.Dto.Move, Chess.Engine.Components.Move>()
                .ForMember(x => x.DepartureSquare, act => act.MapFrom(x => x.DepartureSquareName.ToChessBoardSquare()))
                .ForMember(x => x.ArrivalSquare, act => act.MapFrom(x => x.ArrivalSquareName.ToChessBoardSquare()))
                .PreserveReferences();

            CreateMap<Chess.RestApi.Data.Entities.Move, Chess.RestApi.Core.Dto.Move>()
                .ForMember(x => x.DepartureSquareName, act => act.MapFrom(x => x.DepartureSquareName))
                .ForMember(x => x.ArrivalSquareName, act => act.MapFrom(x => x.ArrivalSquareName))
                .PreserveReferences();
        }
    }
}
