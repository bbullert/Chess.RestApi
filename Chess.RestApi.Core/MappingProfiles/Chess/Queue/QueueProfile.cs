using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class QueueProfile : Profile
    {
        public QueueProfile()
        {
            CreateMap<Chess.RestApi.Data.Entities.Queue, Chess.RestApi.Core.Dto.Queue>();
            CreateMap<Chess.RestApi.Core.Dto.Queue, Chess.RestApi.Data.Entities.Queue>();
        }
    }
}
