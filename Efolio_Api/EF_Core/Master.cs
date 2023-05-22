using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Efolio_Api.EF_Core
{
    public class Master
    {
        
       

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BindNever]
        public int MasterId { get; set; }
        public List<Projects> Project { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Education> Education { get; set; }
        public Profile profile { get; set; }  
    }
}
