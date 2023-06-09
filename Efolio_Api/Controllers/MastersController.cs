﻿using Efolio_Api.EF_Core;
using Efolio_Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Efolio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MastersController : ControllerBase
    {
        private readonly DbHelper dbHelper;

        public MastersController(EF_DataContext eF_DataContext)
        {
            dbHelper = new DbHelper(eF_DataContext);
        }
        [HttpPost("PostMasters")]
        public async Task<IActionResult> PostMaster([FromBody] Master master)
        {
            var result = dbHelper.PostMaster(master);
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
