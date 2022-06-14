using Microsoft.AspNetCore.SignalR;

namespace MyNewServerAPI.Hubs
{
    public class MyHub : Hub
    {
        public async Task Changed(string usersent, string sender)
        {
            await Clients.All.SendAsync("ChangeReceived", usersent, sender);
        }
    }
}
