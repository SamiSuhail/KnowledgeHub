using KnowledgeHub.Data;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Models.Course;
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
        public IEnumerable<CourseCategoryDisplayModel> AllCategories()
            => data.Categories
            .Select(c => new CourseCategoryDisplayModel()
            {
                Name = c.Name,
                Description = c.Description
            })
            .ToList();

        public IEnumerable<CourseAllDisplayModel> AllCourses()
            => data.Courses
            .Select(c => new CourseAllDisplayModel()
            {
                Category = c.Category.Name,
                Description = c.Description,
                LastModified = c.LastModified,
                Name = c.Name,
            })
            .ToList();

        public IEnumerable<CourseAllDisplayModel> AllCourses(string category)
            => data.Courses
            .Where(c => c.Category.Name == category)
            .Select(c => new CourseAllDisplayModel()
            {
                Category = c.Category.Name,
                Description = c.Description,
                LastModified = c.LastModified,
                Name = c.Name,
            })
            .ToList();

        public void Create(CourseCreateFormModel model)
        {
            var category = AllCategories().FirstOrDefault(c => c.Name == model.Category);

            var newCourse = new Course()
            {
                Name = model.Name,
                Description = model.Description,
                Category = ToCategory(category),
            };

            data.Courses.Add(newCourse);
            data.SaveChanges();
        }

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

        private static Category ToCategory(CourseCategoryDisplayModel model)
                => new Category() { Name = model.Name, Description = model.Description };
    }
}
