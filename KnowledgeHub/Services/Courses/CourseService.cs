using KnowledgeHub.Data;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Services.Courses.Models;
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
        public IEnumerable<CategoryServiceModel> AllCategories()
            => data.Categories
            .Select(c => new CategoryServiceModel()
            {
                Name = c.Name,
                Description = c.Description
            })
            .ToList();

        private string GetCategoryName(int id)
            => data.Categories.FirstOrDefault(c => c.Id == id).Name;


        public IEnumerable<CourseAllServiceModel> AllCourses(string category)
        {
            if (category == null)
            {
                return data.Courses
              .Select(c => new CourseAllServiceModel()
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
              .Select(c => new CourseAllServiceModel()
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

        public IEnumerable<TopicServiceModel> AllTopics(string courseId)
            => data.Topics.Where(t => t.CourseId.ToString() == courseId)
            .Select(t => new TopicServiceModel()
            {
                Id = t.Id,
                CourseId = t.CourseId,
                Name = t.Name,
            });

        
        public bool AddTopic(int courseId, CourseAddTopicServiceModel model)
        {
            if (data.Topics.Where(t => t.CourseId == courseId).Any(t => t.Name == model.Name))
            {
                return false;
            }

            data.Topics.Add(new Topic()
            {
                CourseId = courseId,
                Description = model.Description,
                Name = model.Name,
            });

            data.SaveChanges();
            return true;
        }
        public void Create(CourseCreateServiceModel model)
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

        public CourseDetailsServiceModel Details(int id)
        {
            var course = data.Courses.FirstOrDefault(c => c.Id == id);
            var topics = data.Topics.Where(t => t.CourseId == id)
                    .Select(t => new TopicServiceModel()
                    {
                        CourseId = t.CourseId,
                        Id = t.Id,
                        Name = t.Name,
                    });

            return new CourseDetailsServiceModel()
            {
                Category = GetCategoryName(course.CategoryId),
                CreatedOn = course.CreatedOn,
                Description = course.Description,
                Id = course.Id,
                ImageUrl = course.ImageUrl,
                LastModified = course.LastModified,
                Name = course.Name,
                Topics = topics
            };
        }


        


        private Category ToCategory(CategoryServiceModel model)
                => data.Categories.FirstOrDefault(c => c.Name == model.Name);


    }
}
