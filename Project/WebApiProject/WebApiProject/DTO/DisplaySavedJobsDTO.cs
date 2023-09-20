using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.DTO
{
    public class DisplaySavedJobsDTO
    {
     
        public List<displaySavedJobsDTOO> SavedJobs { get; set; }=new List<displaySavedJobsDTOO>();
    }
    public class displaySavedJobsDTOO{
   public int JobId { get; set; }
    public string Title { get; set; }
    public double Budget { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public string ProfileId { set; get; }
    public int locationId { get; set; }
   }
 }

    
