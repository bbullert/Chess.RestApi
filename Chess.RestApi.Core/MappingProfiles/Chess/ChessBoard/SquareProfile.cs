using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class SquareProfile : Profile
    {
        public SquareProfile()
        {
            CreateMap<Chess.Engine.Components.Square, Chess.RestApi.Core.Dto.Square>();
        }
    }
}
