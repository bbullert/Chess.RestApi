using Chess.RestApi.Data.Common;

namespace Chess.RestApi.Core.Hubs
{
    public interface IApiHub : IScopedDependency
    {
        Task JoinGroupAsync(string groupGuid);
        Task LeaveGroupAsync(string groupGuid);
        Task GameStartedAsync(string gameGuid, string queueGuid);
        Task GameEndedAsync(string gameGuid);
        Task GameStateChangedAsync(string gameGuid);
        Task DrawOfferedAsync(string gameGuid);
        Task DrawOfferAcceptedAsync(string gameGuid);
        Task DrawOfferDeclinedAsync(string gameGuid);
        Task QueueStateChangedAsync(string queueGuid);
    }
}
