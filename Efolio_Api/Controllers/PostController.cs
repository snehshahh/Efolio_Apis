using Efolio_Api.EF_Core;
using Efolio_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Efolio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
       
        private readonly DbHelper dbHelper;

        public PostController(EF_DataContext eF_DataContext)
        {
            dbHelper = new DbHelper(eF_DataContext);
        }

        #region PostApis

        [HttpPost("PostProjects")]

        public async Task<IActionResult> PostProjects([FromBody] Projects  projects)
        {
            var result = dbHelper.PostProjects(projects);
            if (result != false)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(404, new { message = "Failed", StatusCode = 404 });
            }
        }
        
        [HttpPost("PostEducation")]

        public async Task<IActionResult> PostEducation([FromBody] Education education)
        {
            var result = dbHelper.PostEducation(education);
            if (result != false)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(404, new { message = "Failed", StatusCode = 404 });
            }
        }   
        [HttpPost("PostExperience")]

        public async Task<IActionResult> PostExperience([FromBody] Experience experience)
        {
            var result = dbHelper.PostExperience(experience);
            if (result != false)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(404, new { message = "Failed", StatusCode = 404 });
            }
        }
        [HttpPost("PostProfile")]
        public async Task<IActionResult> PostProfile([FromBody] Profile profile)
        {
            var result = dbHelper.PostProfile(profile);
            if (result != false)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(404, new { message = "Failed", StatusCode = 404 });
            }
        }
        #endregion
    }
}
