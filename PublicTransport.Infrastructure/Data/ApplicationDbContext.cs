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

        public DbSet<NewsComments> NewsComments { get; set; }
    }
}