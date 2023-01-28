using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Entities;

namespace Chess.RestApi.Core.Services
{
    public partial class GameEndingService
    {
        public async Task<ISearchResult<Chess.RestApi.Data.Entities.GameEnding>> SearchAsync(GameEndingSearchCriteria criteria)
        {
            var result = await _gameEndingRepository.SearchAsync(criteria);

            return result;
        }
    }
}
