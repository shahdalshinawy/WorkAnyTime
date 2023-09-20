using Lab1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiProject.Models
{
    public class Profile
    {
        [Key]
        [ForeignKey("AUser")]
        public string Id { set; get; }
        public string? name { set; get; }
        public string? address { set; get; }
        public string? title { set; get; }
        public string? description { set; get; }
        public string? workHistory { set; get; }
        public int? fixedSalary { set; get; }

        public string? ProfileImage { get; set; }
        public bool Freelancer { get; set; }
        public bool Client { get; set; }

        //[ForeignKey("education")]
        //public string educationId { set; get; }
        public string? PortfoliTitle { get; set; }
        public string? PortflioDescription { get; set; }
        public string? portfoliolink { get; set; }

        public virtual ApplicationUser? AUser { get; set; }

        //public Role? UserRole { get; set; }
        public List<Job>? jobs { set; get; }
        public List<Education>? education { set; get; }
        public List<Skills>? skill { get; set; }
        public List<Languges>? languge { get; set; }
        public List<SavedJobs> savedJobs { set; get; }
    }
}
