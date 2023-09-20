using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.Repository;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        IRepository<Job> _JobRepository;
        IRepository<JobDTO> _JobDTORepository;
        public JobsController(IRepository<Job> jobRepository, IRepository<JobDTO> jobDTORepository)
        {
            _JobRepository = jobRepository;
            _JobDTORepository = jobDTORepository;
        }


        [HttpGet]
        public IActionResult getAll()
        {
            List<Job> joblist = _JobRepository.GetAll();
            return Ok(joblist);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {

            Job jop = _JobRepository.GetById(id);


            JobssDTO jopDTO = new JobssDTO();
            jopDTO.Id = jop.Id;
            jopDTO.Proposals = new List<ProposalDTO>();

            if (jop.Proposals != null)
            {
                foreach (var item in jop.Proposals)
                {
                    jopDTO.Proposals.Add
                        (
                        new ProposalDTO()
                        {
                            UserId = item.UserId,
                            JobId = item.JobId,
                            CoverLetter = item.CoverLetter,
                            ProposedPrice = item.ProposedPrice,
                        }
                        );
                }
            }

            jopDTO.Reviews = new List<ReviewDTO>();
            if (jop.Reviews != null)
            {
                foreach (var item in jop.Reviews)
                {
                    jopDTO.Reviews.Add
                        (
                        new ReviewDTO()
                        {
                            UserId = item.UserId,
                            JobId = item.JobId,
                            Rating = item.Rating,
                            Comment = item.Comment,
                        }
                        );
                }
            }

            jopDTO.Contracts = new List<ContractDTO>();
            if (jop.Contracts != null)
            {
                foreach (var item in jop.Contracts)
                {
                    jopDTO.Contracts.Add
                        (
                        new ContractDTO()
                        {
                            ClientId = item.ClientId,
                            FreelancerId = item.JobId,
                            JobId = item.JobId,
                            Price = item.Price,
                            CreatedAt = DateTime.UtcNow,

                            CompletedAt = item.CompletedAt,
                        }
                        );
                }
            }

            jopDTO.Description = jop.Description;
            jopDTO.CategoryId = jop.categoryId;
            jopDTO.LocationId = jop.locationId;
            jopDTO.ProfileId = jop.ProfileId;
            jopDTO.Title = jop.Title;
            jopDTO.Field = jop.Field;
            jopDTO.JopBody = jop.JopBody;
            jopDTO.Budget = jop.Budget;
            jopDTO.connects = jop.connects;
            //jopDTO.IsSaved = jop.IsSaved;
            jopDTO.IsHourly = jop.IsHourly;


            return Ok(jopDTO);
        }


        [HttpPost]//api/Jop Post
        public IActionResult New(JobssDTO Newjob)
        {
            if (ModelState.IsValid)
            {
                Job job = new Job
                {
                    JopBody = Newjob.JopBody,
                    Field = Newjob.Field,
                    CreatedAt = DateTime.Now,
                    categoryId = Newjob.CategoryId,
                    Description = Newjob.Description,
                    locationId = Newjob.LocationId,
                    connects = Newjob.connects,
                    //IsSaved=Newjob.IsSaved,
                    IsHourly = Newjob.IsHourly,
                    Title = Newjob.Title,
                    Budget = Newjob.Budget,
                    ProfileId = Newjob.ProfileId,
                };
                }
            return Ok("Posted");
        }
    }
}