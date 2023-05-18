using Efolio_Api.EF_Core;
using Efolio_Api.EF_Core; // Import the appropriate namespace for your project

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
        public List<(int MasterId, string GLink)> IsUserCredentialsValid(string email, string password)
        {
            // Check if there is a user with the given email and password
            bool isValidUser = _context.Logins.Any(u => u.Email == email && u.Password == password);

            if (isValidUser)
            {
                string sqlQuery = $"SELECT * FROM public.\"Links\" WHERE \"Email\" = '{email}';";

                var result = _context.Links.FromSqlRaw(sqlQuery).ToList();

                // Map the result to the desired format (e.g., list of tuples)
                var mappedResult = result.Select(link => (link.MasterId, link.GLink)).ToList();

                return mappedResult;
            }

            return null;
        }

        public string RegisterAndAuthenticateUser(Login login)
        {
            if (_context.Logins.Any(l => l.Email == login.Email))
            {
                return null;
            }

            _context.Logins.Add(login);
            _context.SaveChanges();

            string emailWithoutDomain = login.Email.Split('@')[0]; // Remove domain part of email for URL only
            string url = $"http://example.com?{emailWithoutDomain}";
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
			var result = _context.Projectss.Where(p => p.MasterId == id).ToList();
			return result;
		}
		public List<Experience> GetExperience(int id)
		{
			var result = _context.Experiences.Where(p => p.MasterId == id).ToList();
			return result;
		}
		public List<Education> GetEducations(int id)
		{
			var result = _context.Educations.Where(p => p.MasterId == id).ToList();
			return result;
		}
		public List<Profile> GetProfile(int id)
		{
			var result = _context.Profiles.Where(p => p.MasterId == id).ToList();
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
					MasterId = projects.MasterId,
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
					MasterId = profile.MasterId,
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
					MasterId = education.MasterId,
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
					MasterId = experience.MasterId,
					YearsOfExperience = experience.YearsOfExperience,
					CompanyName = experience.CompanyName,
					Designation = experience.Designation,
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
                var newMaster = new Master
                {
                    MasterId = master.MasterId,
                    profile = master.profile
                };
                _context.Masters.Add(newMaster);
                _context.SaveChanges();

                foreach (var project in master.Project)
                {
                    project.MasterId = master.MasterId;
                    _context.Projectss.Add(project);
                }

                foreach (var experience in master.Experiences)
                {
                    experience.MasterId = master.MasterId;
                    _context.Experiences.Add(experience);
                }

                foreach (var education in master.Education)
                {
					education.MasterId = master.MasterId;
                    _context.Educations.Add(education);
                }

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
			   .FirstOrDefault(e => e.MasterId == profile.MasterId && e.ProfileId==profile.ProfileId);

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
			   .FirstOrDefault(e => e.MasterId == project.MasterId && e.ProjectsId == project.ProjectsId);

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
			   .FirstOrDefault(e => e.MasterId == experience.MasterId  && e.ExperienceId == experience.ExperienceId);

				if (entityToUpdate != null)
				{
					// Update the properties of the entityToUpdate object with the values from the input entity object
					entityToUpdate.YearsOfExperience = experience.YearsOfExperience;
					entityToUpdate.Designation = experience.Designation;
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
               .FirstOrDefault(e => e.MasterId == education.MasterId && e.EducationId == education.EducationId);

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
