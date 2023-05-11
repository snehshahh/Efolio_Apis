using System.ComponentModel.DataAnnotations;

namespace Efolio_Api.EF_Core
{
    public class Projects
    {
        public int Id { get; set; }
		public int NewId { get; set; }

		public string ProjectTitle { get; set; }

        [StringLength(1000)] // Set the maximum length to 1000 characters
        public string ProjectDesc { get; set; }

    }
}
