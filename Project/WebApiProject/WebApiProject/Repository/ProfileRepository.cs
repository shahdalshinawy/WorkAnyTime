using Microsoft.EntityFrameworkCore;
using WebApiProject.DTO;
using WebApiProject.Models;

namespace WebApiProject.Repository
{
    public class ProfileRepository : IprofileRepository
    {
        Context context = new Context();
        private IWebHostEnvironment env;
        public ProfileRepository(Context _context, IWebHostEnvironment env)
        {
            context = _context;
            this.env = env;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Edit(string id, ProfileDataDTO Prof)
        {
            Profile orgp = GetById(id);
            orgp.name = Prof.name;
            orgp.description = Prof.description;
            orgp.title = Prof.title;
            orgp.workHistory = Prof.workHistory;
            orgp.address = Prof.address;
            orgp.fixedSalary = Prof.fixedSalary;
            orgp.description = Prof.description;
            orgp.description = Prof.description;
            context.SaveChanges();
        }

        public void EditImage(string img,string id )
        {
            Profile prof = context.profile.Where(i => i.Id == id).FirstOrDefault();
            //Profile profile = new Profile();
            //profile.Id = id;
            prof.ProfileImage= img;
            context.SaveChanges();
        }

        public void EditProtofilo(ProtofiloDto protofilo, string id)
        {
            Profile prof = context.profile.Where(i => i.Id == id).FirstOrDefault();
            prof.PortfoliTitle = protofilo.PortfoliTitle ;
            prof.portfoliolink = protofilo.portfoliolink ;
            prof.PortflioDescription= protofilo.PortflioDescription;
            context.SaveChanges();
        }

        //public Profile GetAll()
        //{
        //    return context.profile
        //         .AsNoTracking()
        //         .Include(s=>s.skill)
        //         .Include(s => s.education)
        //        .Include(l => l.languge)
        //        .FirstOrDefault();
        //}


        public Profile GetById(string id)
        {
            return context.profile
                    .Include(s => s.skill)
                    .Include(s => s.education)
                    .Include(l => l.languge)
                    .FirstOrDefault(i => i.Id == id);
        }

        public void New(ProfileDTO Prof)
        {
            Profile profi = new Profile();
           /* profi.Client = Prof.Client;
            profi.Freelancer = Prof.Freelancer;*/
            context.profile.Add(profi);
            context.SaveChanges();
        }

        public void New(ProfileDataDTO Profiledata)
        {
            Profile profiled = new Profile();
            Education education= new Education();
            profiled.Id= Profiledata.id;
            //Profile po = GetById(profiled.Id);
            profiled.name = Profiledata.name;
            profiled.title = Profiledata.title;
            profiled.description = Profiledata.description;
            profiled.address = Profiledata.address;
            profiled.fixedSalary = Profiledata.fixedSalary;
            profiled.workHistory = Profiledata.workHistory;
            /* profiled.Freelancer= Profiledata.Freelancer;
             profiled.Client= Profiledata.Client;*/
            //profiled.image=Profiledata.
            context.profile.Add(profiled);
            context.SaveChanges();

            //foreach (var item in Profiledata.eductionDTO)
            //{
            //    Education education = new Education();
            //    education.titleEdu = item.titleEdu;
            //    education.from = item.from;
            //    education.to = item.to;
            //    education.ProfileId = Profiledata.id;
            //    context.educations.Add(education);
            //    context.SaveChanges();
            //}
            foreach (var item in Profiledata.Nameskill)
            {
              Skills skills = new Skills();
                //foreach (var itemt in item.Nameskill)
                //{
                //    skills.Nameskill = itemt;
                //}
                //foreach (var itemt in item.Nameskill)
                //{
                //    foreach (var itemth in skills)
                //    {
                //        itemth.Nameskill = itemt;

                //        itemth.ProfileId = Profiledata.id;
                //        context.Skills.Add(itemth);
                //    }
                //}
                skills.Nameskill = item;
                skills.ProfileId = Profiledata.id;
                context.Skills.Add(skills);
                context.SaveChanges();
            }
            foreach (var item in Profiledata.Namelanguge)
            {
                Languges languges = new Languges();
                languges.Namelanguge = item;
                languges.ProfileId = Profiledata.id;
                context.Languges.Add(languges);
                context.SaveChanges();
            }
            education.titleEdu = Profiledata.titleEdu;
            education.to = Profiledata.to;
            education.from = Profiledata.from;
            education.ProfileId = Profiledata.id;
            context.educations.Add(education);
            context.SaveChanges();
        }

    }
}
