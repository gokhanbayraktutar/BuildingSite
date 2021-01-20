using BuildingSite.Data.Entities;
using System.Data.Entity;

namespace BuildingSite.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<AboutUsPage> AboutUsPages { get; set; }

        public DbSet<ContactPage> ContactPages { get; set; }

        public  DbSet<OurService> OurServices { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectCategory> ProjectCategories { get; set; }

        public DbSet<Reference> References { get; set; }

        public DbSet<SiteConstant> SiteConstants { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<News> Newses { get; set; }
        
        public DbSet<Inbox> Inboxes { get; set; }


        public DbSet<Project_Picture> Project_Pictures { get; set; }

    }
}
