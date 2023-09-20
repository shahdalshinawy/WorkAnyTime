using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.DTO;
using WebApiProject.Repository;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {

        ISkillRepository skillRepository;

        public SkillController(ISkillRepository _skillRepository)
        {
            skillRepository = _skillRepository;
        }
        //[HttpPost("add")]
        //api/Employee Post
        //public ActionResult<DataP> New(SkillsDTO newpsk)
        //{
        //    DataP data = new DataP();
        //    if (ModelState.IsValid)
        //    {
        //        data.Message = "success";
        //        skillRepository.New(newpsk);

        //        return Ok(data);
        //    }
        //    else
        //    {
        //        data.Message = "NotValid";
        //        return Ok(data);
        //    }
        //    return Content("Invalid");
        //}
    }

}
