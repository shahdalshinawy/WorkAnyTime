using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using WebApiProject.Models;

namespace Lab1.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public bool IsFreelancer { get; set; }

    }
}
