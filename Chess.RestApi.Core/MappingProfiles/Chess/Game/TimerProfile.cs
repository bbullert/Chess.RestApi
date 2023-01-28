using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class TimerProfile : Profile
    {
        public TimerProfile()
        {
            CreateMap<Chess.RestApi.Core.Dto.Timer, Chess.Engine.Components.Timer>()
                .ForMember(x => x.TimeElapsed, act => act.MapFrom(x => TimeSpan.FromMilliseconds(x.TimeElapsed) ))
                .ForMember(x => x.TimeLeft, act => act.MapFrom(x => 
                    x.TimeLeft.HasValue 
                    ? (TimeSpan?)TimeSpan.FromMilliseconds(x.TimeLeft.Value) 
                    : null
                ))
                .PreserveReferences();

            CreateMap<Chess.Engine.Components.Timer, Chess.RestApi.Core.Dto.Timer>()
                .ForMember(x => x.TimeElapsed, act => act.MapFrom(x => x.TimeElapsed.TotalMilliseconds))
                .ForMember(x => x.TimeLeft, act => act.MapFrom(x => 
                    x.TimeLeft.HasValue 
                    ? (int?)x.TimeLeft.Value.TotalMilliseconds 
                    : null
                ))
                .PreserveReferences();
        }
    }
}
