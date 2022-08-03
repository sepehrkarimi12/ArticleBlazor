using BlazorApp2.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Server.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasOne(p => p.User).WithMany(p => p.Blogs).HasForeignKey(p => p.UserId);

            //modelBuilder.Entity<Blog>().HasMany(p => p.Comments).WithOne(p => p.Blog).HasForeignKey(p => p.)
            modelBuilder.Entity<Comment>().HasOne(p => p.Blog).WithMany(p => p.Comments).HasForeignKey(p => p.BlogId);

            modelBuilder.Entity<User>().HasOne(p => p.Role).WithMany(p => p.Users).HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<User>().HasOne(p => p.Status);

            base.OnModelCreating(modelBuilder);
        }
    }
}
