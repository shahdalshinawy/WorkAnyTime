using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.DTO
{
    public class AddHiringFreelancersDTO
    {
      
        public string ClientId { get; set; }
        public int proposalId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
