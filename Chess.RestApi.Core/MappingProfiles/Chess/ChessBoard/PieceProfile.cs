using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class PieceProfile : Profile
    {
        public PieceProfile()
        {
            CreateMap<Chess.Engine.Components.Piece, Chess.RestApi.Core.Dto.Piece>()
                .PreserveReferences();
            CreateMap<Chess.Engine.Components.IPiece, Chess.RestApi.Core.Dto.Piece>()
                .ConstructUsing((source, context) =>
                {
                    return context.Mapper.Map<Chess.RestApi.Core.Dto.Piece>(source);
                })
                .PreserveReferences();
            CreateMap<Chess.RestApi.Core.Dto.Piece, Chess.Engine.Components.Piece>()
                .PreserveReferences();
        }
    }
}
