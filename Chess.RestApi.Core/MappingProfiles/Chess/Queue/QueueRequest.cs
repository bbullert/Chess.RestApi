using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class QueueRequestProfile : Profile
    {
        public QueueRequestProfile()
        {
            CreateMap<Chess.RestApi.Data.Entities.QueueRequest, Chess.RestApi.Core.Dto.QueueRequest>();
            CreateMap<Chess.RestApi.Core.Dto.QueueRequest, Chess.RestApi.Data.Entities.QueueRequest>();
        }
    }
}
