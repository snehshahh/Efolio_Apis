using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Efolio_Api.EF_Core
{
    public class Education
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BindNever]

        public int EducationId { get; set; }

        public int MasterId { get; set; }
        public string StartingYear { get; set; }
        public string EndYear { get; set; }
        public string InstituteName { get; set; }
        public string Degree { get; set; }

    }

}
