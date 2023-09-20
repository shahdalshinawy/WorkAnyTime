using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public class Hire
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        
        [ForeignKey("Proposal")]
        public int proposalId { get; set; }
        public DateTime CreateAt { get; set; }
        public virtual Proposal Proposal { get; set; }
        
    }
}
