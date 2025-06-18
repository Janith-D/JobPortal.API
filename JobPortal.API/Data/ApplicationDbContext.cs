using JobPortal.API.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Job>()
        .HasOne(j => j.Employer)
        .WithMany(u => u.Jobs)
        .HasForeignKey(j => j.EmployerId)
        .OnDelete(DeleteBehavior.Restrict); // ✅ prevent cascade delete

        modelBuilder.Entity<Application>()
                .HasOne(a => a.JobSeeker)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.JobSeekerId)
                .OnDelete(DeleteBehavior.Cascade); // ✅ one path can still cascade
        }
    }
}
