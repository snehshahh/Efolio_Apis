using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Efolio_Api.EF_Core
{
    public class Link
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BindNever]

        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Master")]
        public int MasterId { get; set; }

        public string Email { get; set; }
        public string GLink { get; set; }
    }
}
