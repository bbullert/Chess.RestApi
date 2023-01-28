using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Contexts;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Data.Repositories
{
    public class PromotionRepository : Repository<Guid, Promotion, ISearchCriteria>, IPromotionRepository
    {
        public PromotionRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
