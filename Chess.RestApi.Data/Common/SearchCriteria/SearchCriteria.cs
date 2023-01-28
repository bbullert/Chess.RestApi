namespace Chess.RestApi.Data.Common
{
    public class SearchCriteria : ISearchCriteria
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<string> SortOrder { get; set; }

        public SearchCriteria()
        {
            PageIndex = Math.Max(1, PageIndex);
            PageSize = int.MaxValue;
        }
    }
}
