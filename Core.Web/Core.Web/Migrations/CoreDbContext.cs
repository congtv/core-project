using Microsoft.EntityFrameworkCore;
using Core.Model.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Core.Web.Migrations
{
    public class CoreDbContext : IdentityDbContext
    {
        public CoreDbContext() : base()
        {

        }
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {

        }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=CoreDb;Uid=root;Pwd=1234;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
            .HasKey(t => new { t.OrderID, t.ProductID });
            modelBuilder.Entity<ProductTag>()
                .HasKey(x => new { x.TagID, x.ProductID });
            modelBuilder.Entity<PostTag>()
                .HasKey(x => new { x.TagID, x.PostID });
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(t => new { t.LoginProvider, t.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(t => new { t.UserId, t.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        }
    }
}
