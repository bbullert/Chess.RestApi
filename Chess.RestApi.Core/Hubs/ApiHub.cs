using Microsoft.AspNetCore.SignalR;

namespace Chess.RestApi.Core.Hubs
{
    public class ApiHub : Hub, IApiHub
    {
        public async Task JoinGroupAsync(string groupGuid)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupGuid);
        }

        public async Task LeaveGroupAsync(string groupGuid)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupGuid);
        }

        public async Task GameStartedAsync(string gameGuid, string queueGuid)
        {
            await Clients.Group(queueGuid).SendAsync("GameStarted", gameGuid);
        }

        public async Task GameEndedAsync(string gameGuid)
        {
            await Clients.Group(gameGuid).SendAsync("GameEnded");
        }

        public async Task GameStateChangedAsync(string gameGuid)
        {
            await Clients.Group(gameGuid).SendAsync("GameStateChanged");
        }

        public async Task DrawOfferedAsync(string gameGuid)
        {
            await Clients.OthersInGroup(gameGuid).SendAsync("DrawOffered");
        }

        public async Task DrawOfferAcceptedAsync(string gameGuid)
        {
            await Clients.OthersInGroup(gameGuid).SendAsync("DrawOfferAccepted");
        }

        public async Task DrawOfferDeclinedAsync(string gameGuid)
        {
            await Clients.OthersInGroup(gameGuid).SendAsync("DrawOfferDeclined");
        }

        public async Task QueueStateChangedAsync(string queueGuid)
        {
            await Clients.Group(queueGuid).SendAsync("QueueStateChanged");
        }
    }
}
