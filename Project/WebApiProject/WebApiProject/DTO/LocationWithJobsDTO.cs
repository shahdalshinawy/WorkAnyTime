using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiProject.Models;

namespace WebApiProject.DTO
{
    public class LocationWithJobsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<JobsLocationDTO> jobs { get; set; } = new List<JobsLocationDTO>();
    }
        public class JobsLocationDTO
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public double Budget { get; set; }
            public Boolean isSaved { get; set; }
            public string Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public int LocationID { get; set; }
            public int categoryId { get; set; }
        }
        
    
}
