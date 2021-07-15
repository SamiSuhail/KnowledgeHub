using KnowledgeHub.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHub.Data 
{
    public class KnowledgeHubDbContext : IdentityDbContext
    {
        public DbSet<Course> Courses;
        public DbSet<Video> Videos;

        public KnowledgeHubDbContext(DbContextOptions<KnowledgeHubDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Videos)
                .WithOne(v => v.Course)
                .HasForeignKey(cv => cv.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
