namespace Efolio_Api.EF_Core
{
    public class Login
    {
        public int Id { get; set; }
		public int NewId { get; set; }

		public string Email { get; set; }
        public string Password { get; set; }
    }
}
