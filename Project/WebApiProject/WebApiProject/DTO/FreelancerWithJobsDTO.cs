using System.ComponentModel.DataAnnotations.Schema;
using WebApiProject.Models;

namespace WebApiProject.DTO
{
    public class FreelancerWithJobsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Budget { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Boolean IsSaved { get; set; }
        public int LocationID { get; set; }
        public int categoryId { get; set; }
        public string freelancerId { get; set; }
        public string clientName { get; set; }
         
    }
}
