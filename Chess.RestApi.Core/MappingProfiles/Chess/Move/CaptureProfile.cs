using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class CaptureProfile : Profile
    {
        public CaptureProfile()
        {
            CreateMap<Chess.RestApi.Core.Dto.Capture, Chess.Engine.Components.Capture>();
            CreateMap<Chess.Engine.Components.Capture, Chess.RestApi.Core.Dto.Capture>()
                .ForMember(x => x.CaptureSquareName, act => act.MapFrom(x => x.CaptureSquare.ToString()));
            CreateMap<Chess.Engine.Components.Capture, Chess.RestApi.Data.Entities.Capture>()
                .ForMember(x => x.CaptureSquareName, act => act.MapFrom(x => x.CaptureSquare.ToString()));
            CreateMap<Chess.RestApi.Data.Entities.Capture, Chess.RestApi.Core.Dto.Capture>();
        }
    }
}
