namespace Chess.RestApi.Data.Common
{
    public interface IDependency
    {

    }

    public interface ITransientDependency : IDependency
    {

    }

    public interface IScopedDependency : IDependency
    {

    }

    public interface ISingletonDependency : IDependency
    {

    }
}
