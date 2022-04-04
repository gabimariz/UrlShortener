using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Url>? Urls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql("server=localhost;username=root;password=root;database=url_shortener",
                new MariaDbServerVersion(new Version(10, 6, 7)));
        }
    }
}
