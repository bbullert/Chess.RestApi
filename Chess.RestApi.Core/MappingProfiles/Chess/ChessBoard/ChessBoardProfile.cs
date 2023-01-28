using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class ChessBoardProfile : Profile
    {
        public ChessBoardProfile()
        {
            CreateMap<Chess.Engine.Components.ChessBoard, Chess.RestApi.Core.Dto.ChessBoard>();
        }
    }
}
