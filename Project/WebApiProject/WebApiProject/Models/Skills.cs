using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public class Skills
    {
        public int Id { get; set; }
        public string Nameskill { get; set; }

        [ForeignKey("Profile")]
        public string ProfileId { get; set; }

        public virtual Profile Profile { get; set; }
        //public List<skillsprofile> skillsprofiles { get; set; }

    }
}
