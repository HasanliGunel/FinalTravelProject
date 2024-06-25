using Entities.Concrete.TableModel;
using Entities.Concrete.TableModel.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleCLaim, ApplicationUserToken>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = TravelDb; User Id = sa; Password=1391; TrustServerCertificate = True; ");
                                       //Data Source=localhost; Initial Catalog=MeyawoDb; User Id=sa; Password=1391;TrustServerCertificate=True;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<CategoryOfBlog> CategoryOfBlogs { get; set; }
        

        public DbSet<Tag> Tags { get; set; } 
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<HomeSlide> HomeSlides { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Testimonial> Testmonials { get; set; }
        public DbSet<TagBlog> TagBlogs { get; set; }
        public DbSet<Service> Services { get; set; }
       
    }
}
