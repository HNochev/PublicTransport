using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PublicTransport.Infrastructure.Data.Models;

namespace PublicTransport.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<WebsiteUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<News> News { get; set; }

        public DbSet<NewsComment> NewsComments { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<PhotoComment> PhotoComments { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<NewsComment>()
                .HasOne(x => x.News)
                .WithMany(x => x.NewsComments)
                .HasForeignKey(x => x.NewsId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<PhotoComment>()
                .HasOne(x => x.Photo)
                .WithMany(x => x.PhotoComments)
                .HasForeignKey(x => x.PhotoId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}