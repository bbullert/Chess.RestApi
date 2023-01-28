using AutoMapper;

namespace Chess.RestApi.Core.MappingProfiles
{
    public class PromotionProfile : Profile
    {
        public PromotionProfile()
        {
            CreateMap<Chess.RestApi.Core.Dto.Promotion, Chess.Engine.Components.Promotion>();
            CreateMap<Chess.Engine.Components.Promotion, Chess.RestApi.Core.Dto.Promotion>();
            CreateMap<Chess.Engine.Components.Promotion, Chess.RestApi.Data.Entities.Promotion>();
            CreateMap<Chess.RestApi.Data.Entities.Promotion, Chess.RestApi.Core.Dto.Promotion>();
        }
    }
}
