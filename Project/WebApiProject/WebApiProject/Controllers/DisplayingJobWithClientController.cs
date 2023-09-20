using Microsoft.AspNetCore.Mvc;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.repo;
using WebApiProject.Repository;


namespace WebApiProject.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class DisplayingJobWithClientController : Controller
	{
		private readonly Ijobing jobwithclient;
        Ireposatory<SavedJobs> savedJobRepo;
		Ireposatory<Job> jobRepo;
        public DisplayingJobWithClientController(Ireposatory<Job> _jobRepo,Ijobing jobwithclient,Ireposatory<SavedJobs> ireposatory)
		{
			this.jobwithclient = jobwithclient;
			savedJobRepo = ireposatory;
			jobRepo = _jobRepo;
		}

		[HttpGet("{currentUserId}")]

		public IActionResult GetTheData(string currentUserId)
		{
            Boolean isSaved1 = false;
            List<JowWithClientDto> jb = new List<JowWithClientDto>();
            List<SavedJobs> savedJobs1 = savedJobRepo.getall();
			List<SavedJobs> savedJobs2 = new List<SavedJobs>();
            List<Job> g = jobwithclient.getall();
			foreach (SavedJobs savedJobs in savedJobs1)
			{
			 if(savedJobs.UserId == currentUserId)
				{
					savedJobs2.Add(savedJobs);
				} 
			}
                foreach (Job job in g)
			    {
				foreach (SavedJobs savedJobs in savedJobs2)
				{
				   if (savedJobs.JobId == job.Id)
					{
						isSaved1 = true;
					}
				}
                JowWithClientDto jw = new JowWithClientDto();
				jw.OwnerOfAccountIdThatPostedThisJob = job.Id;
				jw.jobDescription = job.Description;
				jw.jobPrice = job.Budget;
				//jw.starsOfClient = job.Profile.stars;
				jw.jobName = job.Title;
				jw.TimeTheJobWasPostedIn = job.CreatedAt;
				jw.isHourly = job.IsHourly;
				jw.NameOfClient = job.Profile.name;
				
				jw.proposalNumber = job.Proposals.Count();
				jw.connectsNeedForThisJob = job.connects;
				jw.totalPriceThatClientPayed = 4;
				jw.isSaved = isSaved1;
				jb.Add(jw);
                isSaved1 = false;
            }
			

            return Ok(jb);
		}
		[HttpGet("{JobId}:int")]
		public IActionResult GetTheJibById(int JobId)
		{
			return Ok(JobId);
		}
	}
}
