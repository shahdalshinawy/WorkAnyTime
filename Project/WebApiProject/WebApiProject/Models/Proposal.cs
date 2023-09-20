using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public class Proposal
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public int JobId { get; set; }
        public string CoverLetter { get; set; }
        public double ProposedPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Profile User { get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
        public virtual Hire Hire { get; set; }
    }
}