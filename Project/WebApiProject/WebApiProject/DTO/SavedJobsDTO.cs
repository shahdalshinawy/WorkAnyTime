using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.DTO
{
    public class SavedJobsDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int JobId { get; set; }
    }
}
