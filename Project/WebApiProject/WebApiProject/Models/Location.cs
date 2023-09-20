namespace WebApiProject.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Job> Jobs { get; set; }
        public List<Profile> Profiles { get; set; }
    }
}
