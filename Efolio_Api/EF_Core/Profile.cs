using System.ComponentModel.DataAnnotations;

namespace Efolio_Api.EF_Core
{
    public class Profile
    {
        public int Id { get; set; }
		public int NewId { get; set; }

		public string Name { get; set; }

        public byte[] ImageData { get; set; }
        public Uri Twitter {  get; set; }
        public Uri Linkedin { get; set; }   

        [StringLength(1000)]
        public string Bio { get; set; } 
    }
}
