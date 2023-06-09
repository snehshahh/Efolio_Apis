﻿using Efolio_Api.EF_Core;
using Efolio_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Efolio_Api.Controllers
{
	
	public class ProjectsController : Controller
	{
		private readonly DbHelper dbHelper;

		public ProjectsController(EF_DataContext eF_DataContext)
		{
			dbHelper = new DbHelper(eF_DataContext);
		}
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
		[HttpPost("PostProjects")]

		public async Task<IActionResult> PostProjects([FromBody] Projects projects)
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
		[HttpPut("UpdateProjects")]
        public async Task<IActionResult> UpdateProjects([FromBody] Projects projects)
        {
            var result = dbHelper.UpdateProjects(projects);
            if (result != false)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(404, new { message = "Failed", StatusCode = 404 });
            }
        }
		[HttpDelete("DeleteProjects")]
        public async Task<IActionResult> DeleteProjects([FromQuery] int projectid, [FromQuery] int masterId)
        {
            var result = dbHelper.DeleteProjects(projectid,masterId);
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
