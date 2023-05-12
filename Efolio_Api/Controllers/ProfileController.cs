using Efolio_Api.EF_Core;
using Efolio_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Efolio_Api.Controllers
{
	public class ProfileController : Controller
	{
		private readonly DbHelper dbHelper;

		public ProfileController(EF_DataContext eF_DataContext)
		{
			dbHelper = new DbHelper(eF_DataContext);
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
	}
}
