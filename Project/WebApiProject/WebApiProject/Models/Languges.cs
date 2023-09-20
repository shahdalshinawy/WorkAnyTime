using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public class Languges
    {
        public int Id { get; set; }
        public string Namelanguge { get; set; }

        [ForeignKey("Profile")]
        public string ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
