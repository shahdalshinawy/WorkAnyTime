using System.Text.Json.Serialization;

namespace WebApiProject.DTO
{
    public class ProfileDataDTO
    {
        public string id { get; set; }
        public string? name { set; get; }
        public string? address { set; get; }
        public string? title { set; get; }
        public string? description { set; get; }
        public string? workHistory { set; get; }
        public int? fixedSalary { set; get; }
        public Boolean Freelancer { set; get; }
        public Boolean Client { set; get; }
        public string? titleEdu { set; get; }
        public DateTime? from { set; get; }
        public DateTime? to { set; get; }

        public List<string>? Nameskill { set; get; } = new List<string>();
        public List<string>? Namelanguge { set; get; } = new List<string>();

    }

    public class EductionDTO
    {
        public string? titleEdu { set; get; }
        public DateTime from { set; get; }
        public DateTime to { set; get; }
    }
    //public class SkillsDTO
    //{
    //    public string ProfileId { get; set; }
    //    public List<string> Nameskill { set; get; }= new List<string>();
    //    //public string Nameskill { set; get; }
    //}
    //public class LangugeDTO
    //{
    //    public string? Namelanguge { set; get; }

    //}
}
