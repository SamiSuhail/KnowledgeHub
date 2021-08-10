using KnowledgeHub.Data;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Models.Courses;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeHub.Services.Courses
{
    public class CourseService : ICourseService
    {
        private KnowledgeHubDbContext data;
        public CourseService(KnowledgeHubDbContext data)
        {
            this.data = data;
        }
        public IEnumerable<CategoryDisplayModel> AllCategories()
            => data.Categories
            .Select(c => new CategoryDisplayModel()
            {
                Name = c.Name,
                Description = c.Description
            })
            .ToList();

        private string GetCategoryName(int id)
            => data.Categories.FirstOrDefault(c => c.Id == id).Name;


        public IEnumerable<CourseAllDisplayModel> AllCourses(string category)
        {
            if (category == null)
            {
                return data.Courses
              .Select(c => new CourseAllDisplayModel()
              {
                  Id = c.Id,
                  Category = c.Category.Name,
                  Description = c.Description,
                  CreatedOn = c.CreatedOn,
                  Name = c.Name,
                  ImageUrl = c.ImageUrl
              })
              .ToList();
            }

            return data.Courses
              .Where(c => c.Category.Name == category)
              .Select(c => new CourseAllDisplayModel()
              {
                  Id = c.Id,
                  Category = c.Category.Name,
                  Description = c.Description,
                  CreatedOn = c.CreatedOn,
                  Name = c.Name,
                  ImageUrl = c.ImageUrl
              })
              .ToList();
        }

        public IEnumerable<Topic> AllTopics(string courseId)
            => data.Topics.Where(t => t.CourseId.ToString() == courseId);
        public void AddTopic(int courseId, CourseAddTopicFormModel model)
        {
            data.Topics.Add(new Topic()
            {
                CourseId = courseId,
                Description = model.Description,
                Name = model.Name,
            });

            data.SaveChanges();
        }
        public void Create(CourseCreateFormModel model)
        {
            var category = AllCategories().FirstOrDefault(c => c.Name == model.Category);

            var newCourse = new Course()
            {
                Name = model.Name,
                Description = model.Description,
                Category = ToCategory(category),
                ImageUrl = model.ImageUrl,
            };

            if (model.ImageUrl == null)
            {
                newCourse.ImageUrl = @"https://elearningindustry.com/wp-content/uploads/2020/01/designing-effective-elearning-courses.jpg";
            }

            data.Courses.Add(newCourse);
            data.SaveChanges();
        }

        public CourseDetailsDisplayModel Details(int id)
        {
            var course = data.Courses.FirstOrDefault(c => c.Id == id);

            return new CourseDetailsDisplayModel() 
            { 
                Category = GetCategoryName(course.CategoryId),
                CreatedOn = course.CreatedOn,
                Description = course.Description,
                Id = course.Id,
                ImageUrl = course.ImageUrl,
                LastModified = course.LastModified,
                Name = course.Name,
            };
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


        private Category ToCategory(CategoryDisplayModel model)
                => data.Categories.FirstOrDefault(c => c.Name == model.Name);

        
    }
}
