using ChatDemo.Service;
using Microsoft.AspNetCore.SignalR;

namespace ChatDemo.Hubs
{
    public sealed class ChatHub : Hub
    {
        private readonly ChatService _chatService;

        public ChatHub(ChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(string user, string message)
        {

            await Clients.All.SendAsync("ReceiveMessage", user, message);

            //  await _chatService.SaveMessage(user, message);

            #region comment

            //await Clients.Others.SendAsync("ReceiveMessage", user, message);

            //send to all expected connectionId
            // await Clients.AllExcept(new List<string> { "connectionId1", "connectionId2" }).SendAsync("ShapeMoved", user, message);

            // send to self
            // await Clients.Caller.SendAsync("ShapeMoved", user, message);

            //send to group
            // await Clients.Groups("").SendAsync("ShapeMoved", user, message);

            //send to every one in groub and not send the caller  
            // await Clients.OthersInGroup("").SendAsync("ShapeMoved", user, message);

            //send to connection Id
            //await Clients.Clients("connection iD").SendAsync("ShapeMoved", user, message);

            #endregion
        }

        public async Task  JoinGroup(string gname,string user)
        {
           await Groups.AddToGroupAsync(Context.ConnectionId, gname);
            await Clients.OthersInGroup(gname).SendAsync("newMember",user , gname);
        }

        public async Task SendToGroup(string gname,string name,string message)
        {
            //save db
            await Clients.Group(gname).SendAsync("SendGroup", name, gname, message);
        }
    }
}
