using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public class SavedJobs
    {
        public int Id { get; set; }
        [ForeignKey("Profile")]
        public string UserId { get; set; }
        [ForeignKey("Job")]
        public int JobId { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Job Job { get; set; }
    }
}
