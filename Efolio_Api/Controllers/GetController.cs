using Efolio_Api.EF_Core;
using Efolio_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Efolio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetController : Controller
	{
        
        private readonly DbHelper dbHelper;

		public GetController(EF_DataContext eF_DataContext)
		{
			dbHelper = new DbHelper(eF_DataContext);
		}

        #region GetMethods

        [HttpGet("GetProjects")]
		public async Task<IActionResult> GetProjects([FromQuery] int id)
		{
			var result = dbHelper.GetProjects(id);
			if (result != null)
			{
				return Ok(result);
			}
			else
			{
                return StatusCode(404, new { message = "Failed", StatusCode = 404 });
            }
		}

		[HttpGet("GetExperience")]
		public async Task<IActionResult> GetExperience([FromQuery] int id)
		{
			var result = dbHelper.GetExperience(id);
			if (result != null)
			{
				return Ok(result);
			}
			else
			{
                return StatusCode(404, new { message = "Failed", StatusCode = 404 });
            }
		}
		[HttpGet("GetEducations")]
		public async Task<IActionResult> GetEducations([FromQuery] int id)
		{
			var result = dbHelper.GetEducations(id);
			if (result != null)
			{
				return Ok(result);
			}
			else
			{
                return StatusCode(404, new { message = "Failed", StatusCode = 404 });
            }
		}

		[HttpGet("GetProfile")]
        public async Task<IActionResult> GetProfile([FromQuery] int id)
        {
            var result = dbHelper.GetProfile(id);
            if (result != null)
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
