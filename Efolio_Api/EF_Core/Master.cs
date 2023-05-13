using System.ComponentModel.DataAnnotations;

namespace Efolio_Api.EF_Core
{
    public class Master
    {
        #region Ids
        public int Id { get; set; }
        public int NewId { get; set; }
        #endregion

        #region Profile
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
        public Uri Twitter { get; set; }
        public Uri Linkedin { get; set; }

        [StringLength(1000)]
        public string Bio { get; set; }

        #endregion

        #region Experience
        public int YearsOfExperience { get; set; }
        public string CompanyName { get; set; }
        public string Desgination { get; set; }
        public string CompanyDescription { get; set; }
        #endregion

        #region Education
        public string StartingYear { get; set; }
        public string EndYear { get; set; }
        public string InstituteName { get; set; }
        public string Degree { get; set; }
        #endregion

        #region Projects
        public string ProjectTitle { get; set; }

        [StringLength(1000)] // Set the maximum length to 1000 characters
        public string ProjectDesc { get; set; }
        #endregion

    }
}
