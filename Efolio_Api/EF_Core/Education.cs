namespace Efolio_Api.EF_Core
{
    public class Education
    {
        public int Id { get; set; }
        public int NewId { get; set; }
        public string StartingYear { get; set; }
        public string EndYear { get; set; }
        public string InstituteName { get; set; }
        public string Degree { get; set; }
    }
}
