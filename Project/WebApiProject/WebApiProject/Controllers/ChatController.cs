using Lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.MyHubs;

namespace WebApiProject.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        //private readonly IHubContext<ChatHub> _hubContext;
        private readonly Context context;

        public ChatController(IHubContext<ChatHub> hubContext, Context _Context)
        {
            context = _Context;
        }
        [HttpPost("SendMessage")]
        public IActionResult SendMessage(ChatDTO msg)
        {
            Message message = new Message
            {
                Content = msg.msgText,
                RecieveId = msg.ReciverId,
                SenderId = msg.SenderId,
                CreatedAt = DateTime.Now,
            };

            context.Message.Add(message);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("GetMessage")]
        public IActionResult GetMessage(string sender, string reciver)
        {
            List<Message> messages = context.Message.Where(m => (m.SenderId == sender && m.RecieveId == reciver)
            || (m.SenderId == reciver && m.RecieveId == sender)
            ).Include(u=>u.Senderuser).Include(u => u.Recieveuser).ToList();
            return Ok(messages);
        }

        [HttpGet("GetChatUsers")]
        public IActionResult GetChatUsers(string OwnerAccountId) 
        {
            List<ApplicationUser> names = new List<ApplicationUser>();
            List<string> reciverrr = context.Message.Where(s => s.SenderId == OwnerAccountId).Select(r => r.RecieveId).ToList();
            foreach (var item in reciverrr)
            {
                ApplicationUser name = context.Users.Where(i => i.Id == item).FirstOrDefault();
                names.Add(name);
            }
            names = names.Distinct().ToList();
            return Ok(names);


        }
        [HttpGet("GetUserName")]
        public IActionResult GetUserName(string userId)
        {
            ApplicationUser username=context.Users.Where(u=>u.Id == userId).FirstOrDefault();
            return Ok(username);

        }
       
    }
}
