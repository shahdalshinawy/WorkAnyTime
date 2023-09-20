using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using WebApiProject.DTO;
using WebApiProject.Models;
using WebApiProject.Repository;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "https://localhost:4500/", headers: "*", methods: "*")]

    public class ProfileController : ControllerBase
    {

        IprofileRepository profileRepository;
        private static IWebHostEnvironment webHost;

        public ProfileController(IprofileRepository _profileRepository, IWebHostEnvironment _webHost)
        {
            profileRepository = _profileRepository;
            webHost = _webHost;

        }

        [HttpPost("NewData")]
        //api/Employee Post
        public ActionResult<DataP> New(ProfileDataDTO newprof)
        {
            DataP data = new DataP();
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (ModelState.IsValid)
                {
                    data.Message = "success";
                    data.IsPass = true;
                    profileRepository.New(newprof);

                    return Ok(data);
                }
                else
                {
                    data.Message = "no";
                    data.IsPass = false;
                    return Ok(data);
                }
            return Content("Invalid");
        }
        [HttpPut("edit/{id}")]
        //api/ProfileData/1 Put
        public IActionResult Edit(string id, ProfileDataDTO newPD)
        {
            DataP data = new DataP();
            if (ModelState.IsValid)
            {
                data.Message = "success";
                profileRepository.Edit(id, newPD);
                return Ok(data);

            }
            else
            {
                data.Message = "NotValid";
                return Ok(data);
            }
            return Content("Invalid");

        }
        [HttpPost("NewCorF")]
        //api/Employee Post
        public IActionResult New(ProfileDTO newprof)
        {
            DataP data = new DataP();
            if (ModelState.IsValid)
            {
                data.Message = "success";
                profileRepository.New(newprof);

                return Ok(newprof);
            }
            else
            {
                data.Message = "NotValid";
                return Ok(data);
            }
            return Content("Invalid");
        }

        [HttpPut("editImage/{id}")]
        //api/ProfileData/1 Put
        public async Task<IActionResult> EditImag(IFormFile File,[FromRoute]string id)
        {
            
            DataP data = new DataP();
            if (ModelState.IsValid)
            {
                data.Message = "success";
                string filename = string.Empty;
                if(File==null || File.Length == 0)
                {
                    return BadRequest(new {message="Error"});
                }
                string myuploadimage = Path.Combine(webHost.WebRootPath, "images");
                filename = File.FileName;
                string fullPath= Path.Combine(myuploadimage,filename);
                using(var stream =new FileStream(fullPath, FileMode.Create))
                {
                    await File.CopyToAsync(stream);
                }
                
                string url = "http://localhost:5294/images/";
                string savedPath = url + filename;
                //string savedPath =filename;
                profileRepository.EditImage(savedPath, id);
                return Ok(new { Message = "success" });

            }
            else
            {
                data.Message = "NotValid";
                return Ok(data);
            }
            return Content("Invalid");

        }
        [HttpPut("editProtofilo/{id}")]
        //api/Employee Post
        public IActionResult EditProtofilo(ProtofiloDto protofilo, [FromRoute] string id)
        {
            DataP data = new DataP();
            if (ModelState.IsValid)
            {
                data.Message = "success";
                profileRepository.EditProtofilo(protofilo,id);

                return Ok(protofilo);
            }
            else
            {
                data.Message = "NotValid";
                return Ok(data);
            }
            return Content("Invalid");
        }
        //[HttpGet("Myprofile")]
        //public IActionResult getAll()
        //{
        //    DataP data = new DataP();
        //    if (ModelState.IsValid)
        //    {
        //        Profile proflist =
        //        profileRepository.GetAll();
        //    return Ok(proflist);
        //    }
        //    else
        //    {
        //        data.Message = "NotValid";
        //        return Ok(data);
        //    }
        //    return Content("Invalid");
        //}
        [HttpGet("Myprofile/{id}")]
      /*  [Authorize(Roles = "freelancer")]*/
        public IActionResult getbyid(string id)
        {
            DataP data = new DataP();
            if (ModelState.IsValid)
            {
                Profile proflist =
            profileRepository.GetById(id);
                return Ok(proflist);
            }
            else
            {
                data.Message = "NotValid";
            }
            return Content("Invalid");
        }

    }
}
