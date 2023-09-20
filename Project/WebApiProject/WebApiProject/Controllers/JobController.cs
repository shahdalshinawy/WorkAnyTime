using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.repo;
using WebApiProject.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        Ireposatory<Job> jobRepo;

        public JobController(Ireposatory<Job> jobRepo) {
            this.jobRepo = jobRepo;
        }


       
    


}
}