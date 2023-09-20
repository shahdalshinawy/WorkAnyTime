using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.repo;
using Microsoft.AspNetCore.Mvc.Routing;
using static WebApiProject.DTO.ClientWithhJobsDTO;
using Lab1.Models;

namespace WebApiProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerJobController : ControllerBase
    {
        Ireposatory<Job> JobRepo;
        Ireposatory<Profile> userRepo;
        Ireposatory<SavedJobs> savedJobRepo;
        public FreelancerJobController(Ireposatory<SavedJobs> ireposatory,Ireposatory<Job> _ireposatory, Ireposatory<Profile> _userRepo)
        {
            JobRepo = _ireposatory;
            userRepo = _userRepo;
            savedJobRepo = ireposatory;
        }
        [HttpGet("Jobs")]
        public IActionResult getjobs() {
            Boolean isSaved1 = false;
          List<Job> jobs = JobRepo.getall("Profile","SavedJobs");
            List<SavedJobs> savedJobs1 = savedJobRepo.getall();
          List<FreelancerWithJobsDTO> jobsDTO = new List<FreelancerWithJobsDTO>();
            foreach (Job job in jobs)
            {
                foreach (SavedJobs savedJobs in savedJobs1)
                {
                    if (job.Id == savedJobs.JobId)
                    {
                        isSaved1 = true;
                    }
                }
                    //Profile client = userRepo.getbyidString(job.ProfileId);
                    jobsDTO.Add(new FreelancerWithJobsDTO()
                    {
                        Id = job.Id,
                        Title = job.Title,
                        Description = job.Description,
                        LocationID = job.locationId,
                        categoryId = job.categoryId,
                        CreatedAt = job.CreatedAt,
                        Budget = job.Budget,
                        IsSaved = isSaved1,
                        freelancerId = job.ProfileId,
                        clientName = job.Profile.name,
                       
                    });
                isSaved1 = false;
            }
            
           
            return Ok(jobsDTO);
        }

        //[HttpGet("{id:int}")]
        //public IActionResult SavedJob(int id)
        //{
        //    Job oldJob = JobRepo.getbyidInt(id);
        //    oldJob.IsSaved = true;
        //    JobRepo.update(oldJob);
        //    return Ok("Updated");
        //}

        [HttpGet("{currentUserId}")]
        public IActionResult getAllSavedJobs(string currentUserId)
        {
            //int count = 0;
            List<SavedJobs> savedJobs = savedJobRepo.getall("Job");
            List<SavedJobs> jobs=savedJobs.Where(s=>s.UserId== currentUserId).ToList();
            DisplaySavedJobsDTO displayJobDTO = new DisplaySavedJobsDTO();
            foreach (SavedJobs savedJob in jobs)
            {
                //if (jobs.Count(j=>j.JobId==savedJob.JobId)==1)
                //{
                    Job job = JobRepo.getbyidInt(savedJob.JobId);
                    //SavedJobs savedJobs1 = jobs.FirstOrDefault(j => j.JobId == job.Id);
                    displaySavedJobsDTOO jobsDTO = new displaySavedJobsDTOO();
                    jobsDTO.Title = job.Title;
                    jobsDTO.Description = job.Description;
                    jobsDTO.CreatedAt = job.CreatedAt;
                    jobsDTO.Budget = job.Budget;
                    jobsDTO.JobId = savedJob.JobId;
                    jobsDTO.locationId = job.locationId;


                    displayJobDTO.SavedJobs.Add(jobsDTO);
                //}
               
                }
            return Ok(displayJobDTO);
        }

        [HttpDelete("{jobId:int}")]
        public IActionResult deleteSavedJob(int jobId)
        {
            List<SavedJobs> savedJobs=savedJobRepo.getall();
            SavedJobs savedJob =savedJobs.FirstOrDefault(s=>s.JobId==jobId);
            savedJobRepo.delete(savedJob);
            return Ok("Deleted");
        }

        [HttpGet("CountSavedJobs/{currentUserId}")]
        public IActionResult countSavedJobs(string currentUserId)
        {
            List<SavedJobs> savedJobs = savedJobRepo.getall();
            int count = 0;
            foreach (SavedJobs job in savedJobs)
            {
                if (job.UserId==currentUserId)
                {
                    count++;
                }
            }
            return Ok(count);
        }
        [HttpPost("AddSavedJob")]
        public IActionResult AddJobSaved(SavedJobsDTO newSavedJob)
        {
            SavedJobs savedJobs = new SavedJobs();
            savedJobs.Id = newSavedJob.Id;
            savedJobs.JobId = newSavedJob.JobId;
            savedJobs.UserId = newSavedJob.UserId;
            savedJobRepo.create(savedJobs);
            return Ok(savedJobs);
        }
      

    }
}
