using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Core.Services
{
    public partial class GameService
    {
        public async Task<ISearchResult<Chess.RestApi.Data.Entities.Game>> SearchAsync(GameSearchCriteria criteria)
        {
            var result = await _gameRepository.SearchAsync(criteria);

            return result;
        }
    }
}
