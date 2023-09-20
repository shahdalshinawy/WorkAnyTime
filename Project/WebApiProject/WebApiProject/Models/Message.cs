using Lab1.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public class Message
    {
        public int Id { get; set; }
        [ForeignKey("Senderuser")]
        public string SenderId { get; set; }
        [ForeignKey("Recieveuser")]
        public string RecieveId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser Recieveuser { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser Senderuser { get; set; }
    }
}