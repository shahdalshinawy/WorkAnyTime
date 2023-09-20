using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public class Education
    {
        public int Id { set; get; }
        public string titleEdu { set; get; }
        public DateTime? from { set; get; }
        public DateTime? to { set; get; }

        [ForeignKey("Profile")]
        public string ProfileId { set; get; }
        public virtual Profile Profile{ get; set; }

    }
}
