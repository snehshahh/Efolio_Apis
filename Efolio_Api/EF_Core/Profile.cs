using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Efolio_Api.EF_Core
{
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BindNever]
        public int ProfileId { get; set; }
		public int MasterId { get; set; }

		public string Name { get; set; }

        public string ImageData { get; set; }
        public Uri Twitter {  get; set; }
        public Uri Linkedin { get; set; }   

        [StringLength(1000)]
        public string Bio { get; set; } 
    }

}
