using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JobId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("ProfileId")]
        public virtual Profile Profile{ get; set; }
        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
    }
}