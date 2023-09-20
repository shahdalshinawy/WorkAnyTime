using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiProject.Models
{
    public class Job
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public double Budget { get; set; }
        public string? Description { get; set; }
        public int connects { get; set; }
        public string? Field { get; set; }
        public string? JopBody { get; set; }
        public DateTime CreatedAt { get; set; }
        //public Boolean isSaved { get; set; }
        public Boolean IsHourly { get; set; }

        [ForeignKey("Profile")]
        public string ProfileId { set; get; }
        [ForeignKey("Location")]
        public int locationId { get; set; }
        [ForeignKey("Category")]
        public int categoryId { get; set; }
        [JsonIgnore]
        public virtual Location? Location { get; set; }
        [JsonIgnore]
        public virtual Category? Category { get; set; }

        [JsonIgnore]
        public virtual Profile? Profile { get; set; }
        [JsonIgnore]
        public List<Proposal>? Proposals { get; set; }
        [JsonIgnore]
        public List<Payment>? Payments { get; set; }
        [JsonIgnore]
        public List<Review>? Reviews { get; set; }

        [JsonIgnore]
        public List<Contract>? Contracts { get; set; }
        public List<SavedJobs>? SavedJobs { get; set; }




    }
}