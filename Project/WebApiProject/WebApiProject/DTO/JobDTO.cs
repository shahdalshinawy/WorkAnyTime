namespace WebApiProject.DTO
{
    public class JobDTO
    {
        public string Title { get; set; }
        public double Budget { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int numberOfConnects { get; set; }
        public string ProfileId { set; get; }
        public int LocationId { set; get; }
        public int CategoryId { set; get; }
        public Boolean isHourly { get; set; }
    }
}
