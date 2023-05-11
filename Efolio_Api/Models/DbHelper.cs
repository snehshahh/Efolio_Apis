using Efolio_Api.EF_Core;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Security;

namespace Efolio_Api.Models
{
	public class DbHelper
	{
		private EF_DataContext _context;
		public DbHelper(EF_DataContext context) { _context = context; }
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
			}

			return null;
		}
		public string RegisterAndAuthenticateUser(Login login)
		{
			_context.Logins.Add(login);
			_context.SaveChanges();
			string url = $"http://example.com?email={login.Email}";
			var links = new Link()
			{
				Email = login.Email,
				GLink = url
			};
			_context.Links.Add(links);
			_context.SaveChanges();
			return url;
		}
		public List<Projects> GetProjects(int id)
		{
			var result = _context.Projectss.Where(p => p.NewId == id).ToList();
			return result;
		}
		public List<Experience> GetExperience(int id)
		{
			var result = _context.Experiences.Where(p => p.NewId == id).ToList();
			return result;
		}
		public List<Education> GetEducations(int id)
		{
			var result = _context.Educations.Where(p => p.NewId == id).ToList();
			return result;
		}
		public List<Profile> GetProfile(int id)
		{
			var result = _context.Profiles.Where(p => p.NewId == id).ToList();
			return result;
		}

		public bool PostProjects(Projects projects)
		{
			try
			{
				var newProject = new Projects
				{
					Id = projects.Id,
					NewId = projects.NewId,
					ProjectTitle = projects.ProjectTitle,
					ProjectDesc = projects.ProjectDesc
				};

				_context.Projectss.Add(newProject);
				_context.SaveChanges();

				return true; 
			}
			catch (Exception ex)
			{
				return false; 
			}
		}
		public bool PostProfile(Profile profile)
		{
			try
			{
				var newProfile = new Profile
				{
					Id = profile.Id,
					NewId = profile.NewId,
                    Name = profile.Name,
					ImageData = profile.ImageData,
					Twitter = profile.Twitter,
					Linkedin= profile.Linkedin,
					Bio= profile.Bio
				};

				_context.Profiles.Add(newProfile);
				_context.SaveChanges();

				return true; 
			}
			catch (Exception ex)
			{
				return false; 
			}
		}
		public bool PostEducation(Education education)
		{
			try
			{
				var newEducation = new Education
				{
					Id = education.Id,
					NewId = education.NewId,
                    StartingYear=education.StartingYear,
                    EndYear=education.EndYear,
                    InstituteName = education.InstituteName,
                    Degree=education.Degree

                };

				_context.Educations.Add(newEducation);
				_context.SaveChanges();

				return true; 
			}
			catch (Exception ex)
			{
				return false; 
			}
		}

		public bool PostExperience(Experience experience)
		{
            try
            {
                var newExperience = new Experience
                {
                    Id = experience.Id,
                    NewId = experience.NewId,
                    YearsOfExperience=experience.YearsOfExperience,
                    CompanyName=experience.CompanyName,
                    Desgination=experience.Desgination,
                    CompanyDescription=experience.CompanyDescription

                };

                _context.Experiences.Add(newExperience);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

	}
}
