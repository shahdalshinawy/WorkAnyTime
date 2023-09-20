using Lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.repo;
using WebApiProject.Repository;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HireController : ControllerBase
    {
        Ireposatory<Hire> hireRepo;
        Ireposatory<Proposal> proposalRepo;
        Ireposatory<Profile> profileRepo;
        Ireposatory<Job> jobRepo;
        UserManager<ApplicationUser> userManager;
        public HireController(Ireposatory<Job> _jobRepo,Ireposatory<Hire> repo, Ireposatory<Proposal> prop, Ireposatory<Profile> prof,UserManager<ApplicationUser> userManager)
        {
            this.hireRepo = repo;
            this.proposalRepo = prop;
            this.profileRepo = prof;
            this.userManager = userManager;
            jobRepo = _jobRepo;
        }
        [HttpPost]
        public IActionResult AddHirringFreelancer(AddHiringFreelancersDTO addHiring)
        {
            Hire hire = new Hire();
           
            hire.ClientId = addHiring.ClientId;
            hire.proposalId = addHiring.proposalId;
            hire.CreateAt=addHiring.CreateAt;
            hireRepo.create(hire);
            return Ok("Added");
        }
        [HttpGet("{currentUserId}")]
        public async Task< IActionResult> getHireForCurrentUser(string currentUserId)
        {
            List<Hire> hire = hireRepo.getall("Proposal");
            List<Proposal> proposals = proposalRepo.getall("Job");
            

             List<JobHiredThatreturnToFreelancer> jobHiring =new List<JobHiredThatreturnToFreelancer>();
            foreach (Hire h in hire)
            {
               foreach(Proposal proposal in proposals)
                {
                    if (h.proposalId == proposal.Id && h.Proposal.UserId==currentUserId)
                    {
                        JobHiredThatreturnToFreelancer job= new JobHiredThatreturnToFreelancer();   
                        job.CoverLetter= proposal.CoverLetter;
                        ApplicationUser applicationUser = await userManager.FindByIdAsync(h.ClientId);
                        job.clientName = applicationUser.UserName;
                        Job job1 = jobRepo.getbyidInt(proposal.JobId);
                        job.JobName = job1.Title;
                        job.JobBudget = job1.Budget;
                        job.JobDescription = job1.Description;
                        job.JobId= proposal.JobId;
                        job.CreatedAt = h.CreateAt;
                        jobHiring.Add(job);
                    }
                }
                
            }
            return Ok(jobHiring);
           

        }
    }
}
