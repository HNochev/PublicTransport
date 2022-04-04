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

        public DbSet<WebsiteUser> WebsiteUsers { get; set; }

        public DbSet<VehicleCondition> VehicleConditions { get; set; }

        public DbSet<PhotoStatus> PhotoStatuses { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Download> Downloads { get; set; }

        public DbSet<Line> Lines { get; set; }

        public DbSet<Stop> Stops { get; set; }

        public DbSet<LineStop> LineStops { get; set; }

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

            builder
               .Entity<Vehicle>()
               .HasOne(x => x.VehicleCondition)
               .WithMany(x => x.Vehicles)
               .HasForeignKey(x => x.VehicleConditionId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
              .Entity<Photo>()
              .HasOne(x => x.PhotoStatus)
              .WithMany(x => x.Photos)
              .HasForeignKey(x => x.PhotoStatusId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<LineStop>()
                .HasKey(x => new { x.LineId, x.StopId });

            base.OnModelCreating(builder);
        }
    }
}