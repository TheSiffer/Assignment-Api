using Assignment_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Api.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<OtpRequest> OtpRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>().HasIndex(u => u.ICNumber).IsUnique();
        }
    }
}
