using Efolio_Api.EF_Core;
using Microsoft.AspNetCore.Mvc;
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

        #region Get Method
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

		#endregion

		#region Post Method

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
					Linkedin = profile.Linkedin,
					Bio = profile.Bio
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
					StartingYear = education.StartingYear,
					EndYear = education.EndYear,
					InstituteName = education.InstituteName,
					Degree = education.Degree

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
					YearsOfExperience = experience.YearsOfExperience,
					CompanyName = experience.CompanyName,
					Desgination = experience.Desgination,
					CompanyDescription = experience.CompanyDescription

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

		public bool PostMaster(Master master)
		{
            try
            {
                var newMasters = new Master
                {
                    Id = master.Id,
                    NewId = master.NewId,
                    YearsOfExperience = master.YearsOfExperience,
                    CompanyName = master.CompanyName,
                    Desgination = master.Desgination,
                    CompanyDescription = master.CompanyDescription,
                    StartingYear = master.StartingYear,
                    EndYear = master.EndYear,
                    InstituteName = master.InstituteName,
                    Degree = master.Degree,
                    ProjectTitle = master.ProjectTitle,
                    ProjectDesc = master.ProjectDesc,
                    Name = master.Name,
                    ImageData = master.ImageData,
                    Twitter = master.Twitter,
                    Linkedin = master.Linkedin,
                    Bio = master.Bio


                };

                _context.Masters.Add(newMasters);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Put Methods

        public bool UpdateProfile(Profile profile)
		{
			try
			{
				var entityToUpdate = _context.Profiles
			   .FirstOrDefault(e => e.NewId == profile.NewId);

				if (entityToUpdate != null)
				{
					// Update the properties of the entityToUpdate object with the values from the input entity object
					entityToUpdate.Name = profile.Name;
					entityToUpdate.ImageData = profile.ImageData;
					entityToUpdate.Twitter = profile.Twitter;
					entityToUpdate.Linkedin = profile.Linkedin;
					entityToUpdate.Bio = profile.Bio;

					_context.SaveChanges();
				}
					return true;
			}
			catch (Exception ex)
			{
				return false;
			}

		}
		public bool UpdateProjects(Projects project)
		{
			try
			{
				var entityToUpdate = _context.Projectss
			   .FirstOrDefault(e => e.NewId == project.NewId);

				if (entityToUpdate != null)
				{
					// Update the properties of the entityToUpdate object with the values from the input entity object
					entityToUpdate.ProjectTitle = project.ProjectTitle;
					entityToUpdate.ProjectDesc = project.ProjectDesc;
					_context.SaveChanges();
				}
					return true;
			}
			catch (Exception ex)
			{
				return false;
			}

		}
		public bool UpdateExperience(Experience experience)
		{
			try
			{
				var entityToUpdate = _context.Experiences
			   .FirstOrDefault(e => e.NewId == experience.NewId);

				if (entityToUpdate != null)
				{
					// Update the properties of the entityToUpdate object with the values from the input entity object
					entityToUpdate.YearsOfExperience = experience.YearsOfExperience;
					entityToUpdate.Desgination = experience.Desgination;
					entityToUpdate.CompanyDescription = experience.CompanyDescription;
					_context.SaveChanges();
				}
					return true;
			}
			catch (Exception ex)
			{
				return false;
			}

		}
		public bool UpdateEducation(Education education)
		{
            try
            {
                var entityToUpdate = _context.Educations
               .FirstOrDefault(e => e.NewId == education.NewId);

                if (entityToUpdate != null)
                {
                    // Update the properties of the entityToUpdate object with the values from the input entity object
                    entityToUpdate.StartingYear = education.StartingYear;
                    entityToUpdate.EndYear = education.EndYear;
                    entityToUpdate.InstituteName = education.InstituteName;
                    entityToUpdate.Degree = education.Degree;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
		#endregion

		

		public bool DeleteProfile(int id)
		{

			var link = _context.Profiles.Find(id);

			if (link == null)
			{
				return false;
			}

			_context.Profiles.Remove(link);
			_context.SaveChanges();

			return true;

		}
		public bool DeleteProjects(int id)
		{

            var delproject = _context.Projectss.Find(id);

            if (delproject == null)
            {
                return false;
            }

            _context.Projectss.Remove(delproject);
			_context.SaveChanges();

            return true;

        }

		public bool DeleteExperience(int id)
		{

            var delExperiences = _context.Experiences.Find(id);

            if (delExperiences == null)
            {
                return false;
            }

            _context.Experiences.Remove(delExperiences);
			_context.SaveChanges();

            return true;

        }
		public bool DeleteEducation(int id)
		{

            var delEdu = _context.Educations.Find(id);

            if (delEdu == null)
            {
                return false;
            }

            _context.Educations.Remove(delEdu);
			_context.SaveChanges();

            return true;

        }

	}

}
