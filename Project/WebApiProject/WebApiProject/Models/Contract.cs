using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int FreelancerId { get; set; }
        public int JobId { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        [ForeignKey("ProfileId")]
        public virtual Profile  Profile{ get; set; }
        [ForeignKey("JobId")]
        public virtual Job? Job { get; set; }
        public List<Payment>? Payments { get; set; }
    }
}
