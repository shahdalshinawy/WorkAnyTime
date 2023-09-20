using System.ComponentModel.DataAnnotations;

namespace Lab1.DTO
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        public string password { get; set; }

    }
}
