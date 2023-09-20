using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static WebApiProject.DTO.ClientWithhJobsDTO;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.repo;
using Lab1.Models;
using Microsoft.AspNetCore.Identity;
using Azure;
using System.Security.Claims;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class ClientJobsController : ControllerBase
    {
        Ireposatory<Profile> userRepo;
        Ireposatory<Job> jobRepo;
        private readonly UserManager<ApplicationUser> userManager;
        public ClientJobsController(Ireposatory<Job> _jobRepo, Ireposatory<Profile> ireposatory, UserManager<ApplicationUser> _userManager)
        {
            userRepo = ireposatory;
            userManager = _userManager;
            jobRepo= _jobRepo;
        }
        [HttpGet("{currentClientID}")]
        public async Task< IActionResult> getJobsClient(string currentClientID)
        {
            List<Profile> clients = userRepo.getall("jobs");
            Profile client = clients.FirstOrDefault(c => c.Id == currentClientID);
            ClientWithhJobsDTO clientWithhJobs = new ClientWithhJobsDTO();

            /*clientWithhJobs.ID = client.Id;*/
            clientWithhJobs.ID = currentClientID;
            //ApplicationUser user = await userManager.FindByIdAsync(id);
            clientWithhJobs.Name =client.name ;
            foreach (Job j in client.jobs)
            {
                ClientJobsDTO j1 = new ClientJobsDTO();
                j1.Id = j.Id;
                j1.Title = j.Title;
                j1.Description = j.Description;
                j1.Budget = j.Budget;
                j1.CreatedAt = j.CreatedAt;
                j1.categoryId = j.categoryId;
                j1.ProfileId= j.ProfileId;
                j1.LocationID = j.locationId;
                clientWithhJobs.jobs.Add(j1);
            }
            return Ok(clientWithhJobs.jobs);
        }
        [HttpPost("AddNewJob")]
        public IActionResult New(JobDTO jobDTO)
        {
            DataP data = new DataP();
            Job _job = new Job();
            _job.Budget = jobDTO.Budget;
            _job.CreatedAt = DateTime.Now;
            _job.Title = jobDTO.Title;
            _job.Description = jobDTO.Description;
            _job.ProfileId = jobDTO.ProfileId;
            _job.connects = jobDTO.numberOfConnects;
            _job.locationId = jobDTO.LocationId;
            _job.categoryId = jobDTO.CategoryId;
            _job.IsHourly = jobDTO.isHourly;

            if (ModelState.IsValid)
            {
                data.Message = "success";
                data.IsPass = true;

                jobRepo.create(_job);

                return Ok(data);
            }
            else
            {
                data.Message = "no";
                data.IsPass = false;
                return Ok(data);
            }
        }
    }
}
