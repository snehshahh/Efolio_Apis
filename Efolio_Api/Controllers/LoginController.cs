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
        [HttpGet("IsUserCredentialsValid")]
        public IActionResult IsUserCredentialsValid([FromQuery] string email, [FromQuery] string password)
        {
            string isValidCredentials = dbHelper.IsUserCredentialsValid(email, password);
            if (isValidCredentials != " " && isValidCredentials != null)
            {
                // User credentials are valid, perform further actions like generating a token or returning a success response
                return Ok("Login successful");
            }

            // User credentials are invalid, return an appropriate response
            return Unauthorized("Invalid email or password");
        }

        [HttpGet("RegisterAndAuthenticateUser")]
		public IActionResult RegisterAndAuthenticateUser([FromQuery] string email, [FromQuery] string password)
		{
			// Create a new user entity with the provided email and password
			var login = new Login
			{
				Email = email,
				Password = password
			};
            string url = dbHelper.RegisterAndAuthenticateUser(login);
            return Ok(url);

		}



	}
}
