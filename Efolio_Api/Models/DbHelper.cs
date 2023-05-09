using Efolio_Api.EF_Core;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace Efolio_Api.Models
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context) {  _context = context; }
        public string IsUserCredentialsValid(string email, string password)
        {
            // Check if there is a user with the given email and password
            bool isValidUser = _context.Logins.Any(u => u.Email == email && u.Password == password);


            if (isValidUser)
            {
                var link = _context.Links.FirstOrDefault(l => l.Email == email);

                if (link != null)
                {
                    return link.GLink;
                }
                else
                {
                    return null;
                }
            }
            //return isValidUser;
        }
    }
}
