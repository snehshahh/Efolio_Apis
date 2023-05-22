using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Efolio_Api.EF_Core
{
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BindNever]
        [JsonIgnore]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Master")]
        [JsonIgnore]
        
        public int MasterId { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
