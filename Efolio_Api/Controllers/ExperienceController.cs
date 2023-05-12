using Efolio_Api.EF_Core;
using Efolio_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Efolio_Api.Controllers
{
	public class ExperienceController : Controller
	{
		private readonly DbHelper dbHelper;

		public ExperienceController(EF_DataContext eF_DataContext)
		{
			dbHelper = new DbHelper(eF_DataContext);
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
		[HttpPut("UpdateExperience")]
        public async Task<IActionResult> UpdateExperience([FromBody] Experience experience)
        {
            var result = dbHelper.UpdateExperience(experience);
            if (result != false)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(404, new { message = "Failed", StatusCode = 404 });
            }
        }
		[HttpDelete("DeleteExperience")]
        public async Task<IActionResult> DeleteExperience([FromQuery] int id)
        {
            var result = dbHelper.DeleteExperience(id);
            if (result != false)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(404, new { message = "Failed", StatusCode = 404 });
            }
        }
	}
}
