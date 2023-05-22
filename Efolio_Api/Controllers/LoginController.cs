using Efolio_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Efolio_Api.EF_Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            List<OutClassLinkAndId> validCredentials = dbHelper.IsUserCredentialsValid(login.Email, login.Password);

            if (validCredentials != null && validCredentials.Any())
            {
                // User credentials are valid, generate a token
                var token = GenerateToken(login); // Replace with your token generation logic

                // Return the token and validCredentials along with a success response
                return Ok(new { token, validCredentials });
            }

            // User credentials are invalid, return an appropriate response
            return StatusCode(404, new { message = "Failed", StatusCode = 404 });
        }

        private string GenerateToken(Login login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("F)J@NcRfUjWnZr4u7x!A%D*G-KaPdSgVkYp2s5v8y/B?E(H+MbQeThWmZq4t6w9z"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Sneh",
                audience: "Onlyme",
                claims: null,
             expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        [HttpPost("SignUp")]
        public IActionResult RegisterAndAuthenticateUser([FromBody] Login model)
        {
            var login = new Login
            {
                Email = model.Email,
                Password = model.Password
            };

            string url = dbHelper.RegisterAndAuthenticateUser(login);

            if (url != null)
            {
                return Ok(new { message = "Login successful" });
            }
            else
            {
                return NotFound(new { message = "Failed", StatusCode = 404 });
            }
        }

    }
}
