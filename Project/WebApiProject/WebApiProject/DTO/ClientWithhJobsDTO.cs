using System.ComponentModel.DataAnnotations.Schema;
using static WebApiProject.DTO.ClientWithhJobsDTO;

namespace WebApiProject.DTO
{
    public class ClientWithhJobsDTO
    {
        public string ID { set; get; }
        public string Name { set; get; }
        public List<ClientJobsDTO> jobs { set; get; }=new List<ClientJobsDTO>();
        public class ClientJobsDTO
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public double Budget { get; set; }
            public string Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public int LocationID { get; set; }
            public int categoryId { get; set; }
            public string ProfileId { get; set; }
        }
    }
}
