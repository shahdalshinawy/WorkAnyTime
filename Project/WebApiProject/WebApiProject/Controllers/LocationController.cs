using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.repo;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        Ireposatory<Location> reposatory;
        public LocationController(Ireposatory<Location> _ireposatory) {
          reposatory = _ireposatory;
        }
        [HttpGet]
        public IActionResult getLocations()
        {
            List<Location> locations=reposatory.getall();
            return Ok(locations);
        }
        [HttpGet("{locationId:int}")]
        public IActionResult getJobsByLocation(int locationId)
        {
            List<Location> locations = reposatory.getall("Jobs");
            Location location = locations.FirstOrDefault(l=>l.Id==locationId);
            LocationWithJobsDTO locationWithJobsDTO = new LocationWithJobsDTO();
            locationWithJobsDTO.Id=locationId;
            locationWithJobsDTO.Name=location.Name;
            foreach(Job j in location.Jobs)
            {
               JobsLocationDTO jobsDTO = new JobsLocationDTO();
                jobsDTO.Id=j.Id;
                jobsDTO.categoryId = j.categoryId;
                jobsDTO.CreatedAt = j.CreatedAt;
                jobsDTO.Budget = j.Budget;
                jobsDTO.Title = j.Title;
                jobsDTO.Description = j.Description;
                jobsDTO.LocationID = j.locationId;

                locationWithJobsDTO.jobs.Add(jobsDTO);
            }
            return Ok(locationWithJobsDTO);

        }
    }
}
