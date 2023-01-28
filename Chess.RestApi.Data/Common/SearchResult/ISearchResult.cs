namespace Chess.RestApi.Data.Common
{
    public interface ISearchResult<TEntity>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }
        public int TotalPages { get; }
        public IEnumerable<TEntity> Rows { get; set; }
    }
}
