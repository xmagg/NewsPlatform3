using Microsoft.EntityFrameworkCore;
using NewsPlatform3.Models;
using System.Runtime.InteropServices;

namespace NewsPlatform3
{
    public class DbNewsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MAGLENUSIA\\SQLEXPRESS;Database=DbNews;TrustServerCertificate=true;Integrated Security=true;");
        }
    }
}
