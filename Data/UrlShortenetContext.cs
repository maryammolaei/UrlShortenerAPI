using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.Data
{
    public class UrlShortenetContext : DbContext
    {
        public UrlShortenetContext(DbContextOptions<UrlShortenetContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UrlManagement>().ToTable(nameof(UrlManagement));
            modelBuilder.Entity<UrlManagement>().Property(p => p.Url).HasMaxLength(200);
            modelBuilder.Entity<UrlManagement>().Property(p => p.ShortUrl).HasMaxLength(50);
        }
        public DbSet<UrlManagement> UrlManagement { get; set; }
    }
}
