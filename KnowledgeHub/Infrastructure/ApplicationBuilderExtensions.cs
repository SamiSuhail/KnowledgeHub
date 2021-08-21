using KnowledgeHub.Data;
using KnowledgeHub.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeHub.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var services = scopedServices.ServiceProvider;

            MigrateDatabase(services);
            SeedCategories(services);
            

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetService<KnowledgeHubDbContext>();

            data.Database.Migrate();
        }

        public static void SeedCategories (IServiceProvider services)
        {
            var data = services.GetService<KnowledgeHubDbContext>();

            if (data.Categories.Any())
            {
                return;
            }

            var seedCategories = new List<Category>()
            {
                new Category() {Name = "IT", Description = "Operating Systems, Networking, Programming"},
                new Category() {Name = "Art", Description = "Painting, Cinema, Music"},
                new Category() {Name = "Science", Description = "Maths, Biology, Physics, Chemistry"},
                new Category() {Name = "General Knowledge", Description = "History, Geography, Politics"},
            };

            data.Categories.AddRange(seedCategories);
            data.SaveChanges();
        }
    }
}
