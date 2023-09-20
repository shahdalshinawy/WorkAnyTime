using WebApiProject.DTO;
using WebApiProject.Models;

namespace WebApiProject.Repository
{
    public class SkillRepository : ISkillRepository
    {
        Context context = new Context();
        public SkillRepository(Context _context)
        {
            context = _context;

        }
        //public void New(SkillsDTO skillsDTO)
        //{
        //   Skills skill = new Skills();
        //    ProfileDataDTO profileDataDTO = new ProfileDataDTO();
        //    //foreach (var itemt in skillsDTO.Nameskill)
        //    //{
        //    //    foreach (var item in skill)
        //    //    {
        //    //        item.Nameskill= itemt;

        //    //        item.ProfileId = profileDataDTO.id;
        //    //    }
        //    //}
        //    //foreach (var item in profileDataDTO.skillsDTOs)
        //    //{
        //    //    Skills skills = new Skills();
        //    //    skills.Nameskill = item.Nameskill;
        //    //    skills.ProfileId = profileDataDTO.id;
        //    //    context.Skills.Add(skills);
        //    //}
        //    context.SaveChanges();

        //}
    }
}
