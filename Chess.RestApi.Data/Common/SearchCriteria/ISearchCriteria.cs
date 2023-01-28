namespace Chess.RestApi.Data.Common
{
    public interface ISearchCriteria
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<string> SortOrder { get; set; }
    }
}
