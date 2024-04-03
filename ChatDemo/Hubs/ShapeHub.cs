using Microsoft.AspNetCore.SignalR;

namespace ChatDemo.Hubs
{
    public sealed class ShapeHub : Hub
    {
        public async Task MoveShape(int x, int y)
        {
            await Clients.All.SendAsync("ShapeMoved", x, y);
        }
    }
}
