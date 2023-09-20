using System.ComponentModel.DataAnnotations.Schema;
using WebApiProject.Models;

namespace WebApiProject.DTO
{
    public class CategoryWithJobsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<JobsCategoryDTO> jobs { get; set; } = new List<JobsCategoryDTO>();
    }
        public class JobsCategoryDTO
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public double Budget { get; set; }
            public string Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public int LocationID { get; set; }
            public int categoryId { get; set; }
        }
        
    
}
