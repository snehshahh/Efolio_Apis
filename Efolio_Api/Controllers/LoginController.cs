using Efolio_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Efolio_Api.EF_Core;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Efolio_Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DbHelper dbHelper;

        public LoginController(EF_DataContext eF_DataContext)
        {
            dbHelper = new DbHelper(eF_DataContext);
        }

        // GET: api/<LoginController>
        [HttpGet("Login")]
        public IActionResult IsUserCredentialsValid([FromQuery] string email, [FromQuery] string password)
        {
            List<(int MasterId, string GLink)> validCredentials =dbHelper.IsUserCredentialsValid(email, password);

            if (validCredentials != null && validCredentials.Any())
            {
                // User credentials are valid, perform further actions like generating a token or returning a success response
                return Ok(new { ValidCredentials = validCredentials });
            }

            // User credentials are invalid, return an appropriate response
            return NotFound(new { message = "Failed", StatusCode = 404 });
        }





        [HttpGet("SignUp")]
		public IActionResult RegisterAndAuthenticateUser([FromQuery] string email, [FromQuery] string password)
		{
			// Create a new user entity with the provided email and password
			var login = new Login
			{
				Email = email,
				Password = password
			};
            string url = dbHelper.RegisterAndAuthenticateUser(login);
            if(url != null)
            {
                return Ok("Login successful");
            }
            else
            {
                return StatusCode(404, new { message = "Failed", StatusCode = 404 });
            }

		}

        
	}
}
