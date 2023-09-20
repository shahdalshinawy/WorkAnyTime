using Microsoft.AspNetCore.SignalR;
using WebApiProject.DTO;

namespace WebApiProject.MyHubs
{
    public class ChatHub:Hub
    {
        public async Task NewMassameAdded ( ChatDTO chatdto)
        {
             Clients.All.SendAsync("ReceiveOneNotify", chatdto);
        }
    }
}
