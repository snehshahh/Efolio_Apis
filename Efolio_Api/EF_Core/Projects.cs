using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Efolio_Api.EF_Core
{
    public class Projects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BindNever]
        public int ProjectsId { get; set; }

        [ForeignKey("Master")]
        public int MasterId { get; set; }

        public string ProjectTitle { get; set; }

        [StringLength(1000)]
        public string ProjectDesc { get; set; }

    }

}
