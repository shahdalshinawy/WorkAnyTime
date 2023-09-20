using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.repo;
using static WebApiProject.DTO.JobWithProposalsDTO;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalsJobController : ControllerBase
    {
        Ireposatory<Job> jobRepo;
        Ireposatory<Profile> freelancerRepo;
        public ProposalsJobController(Ireposatory<Job> ireposatory,Ireposatory<Profile> ireposatory1) {
            jobRepo = ireposatory;
            freelancerRepo = ireposatory1;
        }
        [HttpGet("{jobId:int}")]
        public IActionResult GetAllProposalByJob(int jobId)
        {
            List<Job> jobs = jobRepo.getall("Proposals");
            Job job= jobs.FirstOrDefault(j=>j.Id==jobId);
            JobWithProposalsDTO jobWithProposalsDTO = new JobWithProposalsDTO();
            jobWithProposalsDTO.Id = job.Id;
            foreach (Proposal p in job.Proposals)
            {
                List<Profile> freelancers = freelancerRepo.getall("skill");
                Profile freelancer=freelancers.FirstOrDefault(f=>f.Id==p.UserId);
                ProposalsDTO p1 = new ProposalsDTO();
                p1.Id = p.Id;
                p1.JobId = p.JobId;
                p1.CoverLetter=p.CoverLetter;
                p1.ProposedPrice = p.ProposedPrice;
                p1.CreatedAt = p.CreatedAt;
                //p1.FreelancerEmail = freelancer.Email;
                p1.freelancerID = freelancer.Id;
                p1.FreelancerName= freelancer.name;
                p1.FreelancerImage = freelancer.ProfileImage;
               
               foreach(Skills s in freelancer.skill)
                {
                    p1.skills.Add(s.Nameskill);
                }
                jobWithProposalsDTO.proposals.Add(p1);
                

            }
            return Ok(jobWithProposalsDTO.proposals);

        }
    }
}
