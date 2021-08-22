using KnowledgeHub.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHub.Data 
{
    public class KnowledgeHubDbContext : IdentityDbContext
    {
        public DbSet<Course> Courses { get; init; }
        public DbSet<Video> Videos { get; init; }
        public DbSet<Topic> Topics { get; init; }
        public DbSet<Category> Categories { get; init; }
        public DbSet<Lector> Lectors { get; init; }
        public DbSet<Student> Students { get; init; }

        public KnowledgeHubDbContext(DbContextOptions<KnowledgeHubDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>()
                .HasMany(c => c.Topics)
                .WithOne(v => v.Course)
                .HasForeignKey(cv => cv.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Course>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Topic>()
                .HasMany(t => t.Videos)
                .WithOne(v => v.Topic)
                .HasForeignKey(v => v.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Lector>()
                .HasMany(l => l.Courses)
                .WithOne(c => c.Lector)
                .HasForeignKey(c => c.LectorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Lector>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Lector>(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<StudentsVideos>()
                .HasKey(sv => new { sv.StudentId, sv.VideoId });

            builder.Entity<Student>()
                .HasMany(s => s.VideosWatched)
                .WithOne(sv => sv.Student)
                .HasForeignKey(sv => sv.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Video>()
                .HasMany(v => v.Views)
                .WithOne(sv => sv.Video)
                .HasForeignKey(sv => sv.VideoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Student>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}
