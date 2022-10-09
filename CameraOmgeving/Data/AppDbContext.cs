using CameraOmgeving.Models;
using Microsoft.EntityFrameworkCore;
using CameraOmgeving;


namespace CameraOmgeving.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) :
             base(contextOptions)
        {

        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Camera> cameras { get; set; }


 
    }

}
