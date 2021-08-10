﻿using KnowledgeHub.Data.Models;
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
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Course>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Topic>()
                .HasMany(t => t.Videos)
                .WithOne(v => v.Topic)
                .HasForeignKey(v => v.TopicId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }
    }
}
