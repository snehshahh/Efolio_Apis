using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Efolio_Api.EF_Core
{
    public class Experience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BindNever]
        public int ExperienceId { get; set; }

        public int MasterId { get; set; }

		public int YearsOfExperience { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public string CompanyDescription { get; set;}
    }
}
