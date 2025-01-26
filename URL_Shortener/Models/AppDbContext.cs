using Microsoft.EntityFrameworkCore;
using URL_Shortener.Entity;

namespace URL_Shortener.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenedUrl>(builder =>
            {
                builder.HasIndex(s => s.Code).IsUnique();
                builder.Property(s => s.Code).HasMaxLength(7);
            });
        }
    }
}
