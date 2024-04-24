using Iportfolio.Model;
using Microsoft.EntityFrameworkCore;

namespace Iportfolio.Data
{
	public class AppDbContext:DbContext
	{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}
		public DbSet<Contact> tbl_Contact { get; set; }
		public DbSet<Education> tbl_Education { get; set; }
		public DbSet<Experience> tbl_Experience { get; set; }
		public DbSet<Facts> tbl_Facts { get; set; }
		public DbSet<Profile> tbl_Profile { get; set; }
		public DbSet<Services> tbl_Services { get; set; }
		public DbSet<Skills> tbl_Skills { get; set; }
		public DbSet<SocialNetworks> tbl_SocialNetworks{ get; set; }
		public DbSet<Testimonial> tbl_Testimonial{ get; set; }

	}
}
