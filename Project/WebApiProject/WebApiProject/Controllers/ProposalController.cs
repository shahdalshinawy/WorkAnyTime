using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.repo;
using WebApiProject.Repository;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        IRepository<Proposal> _ProposalRepository;
        IRepository<ProposalDTO> _ProposalDTORepository;
        IRepository<Job> jobRepo;
        IRepository<Profile> freelancerRepo;

        public ProposalController(IRepository<Job> ireposatory, IRepository<Profile> ireposatory1, IRepository<ProposalDTO> ProposalDTORepository, IRepository<Proposal> proposalRepository)
        {
            _ProposalDTORepository = ProposalDTORepository;
            _ProposalRepository = proposalRepository;
            jobRepo= ireposatory;
            freelancerRepo= ireposatory1;
        }

       

        
        [HttpPost]
        public IActionResult newPost (ProposalPostDTO postedPorposal)
        {
            //Profile profile = new Profile();
            //JobDTO jobDTO = new JobDTO();
            Job job = new Job();
            Proposal proposal = new Proposal
            {
                CoverLetter = postedPorposal.CoverLetter,
                ProposedPrice = postedPorposal.ProposedPrice,
                CreatedAt = DateTime.Now,
                //UserId = jobDTO.ProfileId,
                UserId= postedPorposal.UserId,
                JobId = postedPorposal.JobId,

            };
            if (ModelState.IsValid)
            {
                _ProposalRepository.Create(proposal);
                return Ok("Posted");

                //return new StatusCodeResult(StatusCodes.Status201Created);
                

            }
            return BadRequest(ModelState);

        }

        [HttpGet("{jobId:int}")]
        public IActionResult GetAllProposalByJob(int jobId)
        {
            List<Job> jobs = jobRepo.getall("Proposals");
            Job job = jobs.FirstOrDefault(j => j.Id == jobId);
            JobWithProposalsDTO jobWithProposalsDTO = new JobWithProposalsDTO();
            jobWithProposalsDTO.Id = job.Id;
            foreach (Proposal p in job.Proposals)
            {
                List<Profile> freelancers = freelancerRepo.getall("skill");
                Profile freelancer = freelancers.FirstOrDefault(f => f.Id == p.UserId);
                ProposalsDTO p1 = new ProposalsDTO();
                p1.Id = p.Id;
                p1.JobId = p.JobId;
                p1.CoverLetter = p.CoverLetter;
                p1.ProposedPrice = p.ProposedPrice;
                p1.CreatedAt = p.CreatedAt;
                //p1.FreelancerEmail = freelancer.;
                p1.freelancerID = freelancer.Id;
                p1.FreelancerName = freelancer.name;
                p1.FreelancerImage = freelancer.ProfileImage;
                foreach (Skills s in freelancer.skill)
                {
                    p1.skills.Add(s.Nameskill);
                }
                jobWithProposalsDTO.proposals.Add(p1);


            }
            return Ok(jobWithProposalsDTO.proposals);

        }


    }
}
