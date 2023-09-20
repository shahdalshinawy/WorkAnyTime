using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.repo;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalDetailsController : ControllerBase
    {
        Ireposatory<Proposal> proposalRepo;
        Ireposatory<Profile> freelancerRepo;
        public ProposalDetailsController(Ireposatory<Proposal> _proposalRepo, Ireposatory<Profile> _freelancerRepo)
        {
            proposalRepo = _proposalRepo;
            freelancerRepo = _freelancerRepo;
        }
        [HttpGet("{proposalID:int}")]
        public IActionResult getPreposalDetails(int proposalID)
        {
            List<Profile> freelancers = freelancerRepo.getall("skill");
            Proposal proposal = proposalRepo.getbyidInt(proposalID);
            Profile freelancer = freelancers.FirstOrDefault(f => f.Id == proposal.UserId);
            PoposalDetailsDTO proposalDetailsDTO = new PoposalDetailsDTO();
            proposalDetailsDTO.Id = proposalID;
            proposalDetailsDTO.freelancerID = freelancer.Id;
            proposalDetailsDTO.JobId=proposal.JobId;
            proposalDetailsDTO.CoverLetter = proposal.CoverLetter;
            proposalDetailsDTO.ProposedPrice = proposal.ProposedPrice;
            proposalDetailsDTO.CreatedAt = proposal.CreatedAt;
            proposalDetailsDTO.FreelancerName = freelancer.name;
            proposalDetailsDTO.FreelancerImage = freelancer.ProfileImage;
            proposalDetailsDTO.Address = freelancer.address;
            proposalDetailsDTO.Address = freelancer.address;
            //proposalDetailsDTO.FreelancerEmail = freelancer.Email;
            foreach (Skills s in freelancer.skill)
            {
                proposalDetailsDTO.skills.Add(s.Nameskill);
            }
            return Ok(proposalDetailsDTO);

        }
    }
}
