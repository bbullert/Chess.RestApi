namespace Chess.RestApi.Data.Common
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
