using Microsoft.EntityFrameworkCore;

namespace Efolio_Api.EF_Core
{
    public class EF_DataContext: DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options): base(options) { }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Projects> Projectss{ get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education> Educations { get; set; }
    }
}
