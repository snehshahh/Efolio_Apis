using Efolio_Api.EF_Core;
using Efolio_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Efolio_Api.Controllers
{
	public class EducationController : Controller
	{
		private readonly DbHelper dbHelper;

		public EducationController(EF_DataContext eF_DataContext)
		{
			dbHelper = new DbHelper(eF_DataContext);
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
	}
}
