using KnowledgeHub.Data;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeHub.Services
{
    public class CourseService : ICourseService
    {
        private KnowledgeHubDbContext data;
        public CourseService(KnowledgeHubDbContext data)
        {
            this.data = data;
        }
        public IEnumerable<CoursesCategoryModel> AllCategories()
            => data.Categories
            .Select(c => new CoursesCategoryModel()
            {
                Name = c.Name,
                Description = c.Description
            })
            .ToList();

        public void SeedCategories()
        {
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
