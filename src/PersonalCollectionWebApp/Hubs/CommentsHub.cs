using Microsoft.AspNetCore.SignalR;

namespace PersonalCollectionWebApp.Hubs
{
    public class CommentsHub : Hub<ICommentsClient>
    {
        public async Task JoinGroup(int itemId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, itemId.ToString());
        }

        public async Task LeaveGroup(int itemId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, itemId.ToString());
        }

        public async Task SendCommentsUpdate(int itemId)
        {
            await Clients.OthersInGroup(itemId.ToString()).ReceiveCommentsUpdate();
        }
    }

    public interface ICommentsClient
    {
        Task ReceiveCommentsUpdate();
    }
}
