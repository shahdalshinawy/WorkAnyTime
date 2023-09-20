using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.repo;
using WebApiProject.Repository;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Ireposatory<Category> reposatory;
        IjobFixedPrice IjobFixedPrice;
        IJobHourly jobHourly;

        public CategoryController(Ireposatory<Category> _ireposatory,IjobFixedPrice ijobFixed, IJobHourly jobHourly)
        {
            reposatory = _ireposatory;
            this.IjobFixedPrice = ijobFixed;
            this.jobHourly = jobHourly;
        }
        [HttpGet]
        public IActionResult getCategories()
        {
            List<Category> categories = reposatory.getall();
            return Ok(categories);
        }
        [HttpGet("{categoryId:int}")]
        public IActionResult getJobsByCategories(int categoryId)
        {
            List<Category> categories = reposatory.getall("Jobs");
            Category category = categories.FirstOrDefault(l => l.Id == categoryId);
            CategoryWithJobsDTO categoryWithJobsDTO = new CategoryWithJobsDTO();
            categoryWithJobsDTO.Id = categoryId;
            categoryWithJobsDTO.Name = category.Name;
            foreach (Job j in category.Jobs)
            {
                JobsCategoryDTO jobsDTO = new JobsCategoryDTO();
                jobsDTO.Id = j.Id;
                jobsDTO.categoryId = j.categoryId;
                jobsDTO.CreatedAt = j.CreatedAt;
                jobsDTO.Budget = j.Budget;
                jobsDTO.Title = j.Title;
                jobsDTO.Description = j.Description;
                jobsDTO.LocationID = j.locationId;

                categoryWithJobsDTO.jobs.Add(jobsDTO);
            }
            return Ok(categoryWithJobsDTO);

        }
        [HttpGet("GetTheJobByHours")]
        public IActionResult getTheJobHourly()
        {
            List<JowWithClientDto> jw = new List<JowWithClientDto>();
            List<Job> jh = jobHourly.jobshourly();
            foreach (Job job in jh)
            {
                JowWithClientDto jc = new JowWithClientDto();
                jc.OwnerOfAccountIdThatPostedThisJob = job.Id;
                jc.jobDescription = job.Description;
                jc.jobPrice = job.Budget;
               
                jc.jobName = job.Title;
                jc.TimeTheJobWasPostedIn = job.CreatedAt;
                jc.isHourly = job.IsHourly;
                jc.NameOfClient = job.Profile.name;

                jc.proposalNumber = job.Proposals.Count();
                jc.connectsNeedForThisJob = job.connects;
                jc.totalPriceThatClientPayed = 4;
                jw.Add(jc);
            }

            return Ok(jw);

        }

        [HttpGet("GetTheJobByFixedPrice")]
        public IActionResult getTheJobFixedPrice()
        {
            List<JowWithClientDto> jw = new List<JowWithClientDto>();
            List<Job> jh = IjobFixedPrice.jobByFixedPrice();
            foreach (Job job in jh)
            {
                JowWithClientDto jc = new JowWithClientDto();
                jc.OwnerOfAccountIdThatPostedThisJob = job.Id;
                jc.jobDescription = job.Description;
                jc.jobPrice = job.Budget;
               
                jc.jobName = job.Title;
                jc.TimeTheJobWasPostedIn = job.CreatedAt;
                jc.isHourly = job.IsHourly;
                jc.NameOfClient = job.Profile.name;

                jc.proposalNumber = job.Proposals.Count();
                jc.connectsNeedForThisJob = job.connects;
                jc.totalPriceThatClientPayed = 4;
                jw.Add(jc);
            }

            return Ok(jw);

        }

    }
}
