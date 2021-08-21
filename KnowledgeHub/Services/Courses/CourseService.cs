using AutoMapper;
using AutoMapper.QueryableExtensions;
using KnowledgeHub.Data;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Services.Courses.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeHub.Services.Courses
{
    public class CourseService : ICourseService
    {
        private KnowledgeHubDbContext data;
        private readonly IMapper mapper;
        private readonly IConfigurationProvider queryableMapper;

        public CourseService(KnowledgeHubDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
            this.queryableMapper = mapper.ConfigurationProvider;
        }
        public IEnumerable<CategoryServiceModel> AllCategories()
            => data.Categories
            .ProjectTo<CategoryServiceModel>(queryableMapper)
            .ToList();

        private string GetCategoryName(int id)
            => data.Categories.FirstOrDefault(c => c.Id == id).Name;


        public IEnumerable<CourseAllServiceModel> AllCourses(string category)
        {
            if (category == null)
            {
                return data.Courses
              .ProjectTo<CourseAllServiceModel>(queryableMapper)
              .ToList();
            }

            return data.Courses
              .Where(c => c.Category.Name == category)
              .ProjectTo<CourseAllServiceModel>(queryableMapper)
              .ToList();
        }

        public IEnumerable<TopicServiceModel> AllTopics(string courseId)
            => data.Topics.Where(t => t.CourseId.ToString() == courseId)
            .ProjectTo<TopicServiceModel>(queryableMapper);

        
        public bool AddTopic(int courseId, CourseAddTopicServiceModel model)
        {
            if (data.Topics.Where(t => t.CourseId == courseId).Any(t => t.Name == model.Name))
            {
                return false;
            }

            var topic = mapper.Map<CourseAddTopicServiceModel, Topic>(model);
            topic.CourseId = courseId;

            data.Topics.Add(topic);

            data.SaveChanges();
            return true;
        }
        public void Create(CourseCreateServiceModel model)
        {

            var newCourse = mapper.Map<CourseCreateServiceModel, Course>(model);


            if (model.ImageUrl == null)
            {
                newCourse.ImageUrl = @"https://elearningindustry.com/wp-content/uploads/2020/01/designing-effective-elearning-courses.jpg";
            }

            data.Courses.Add(newCourse);
            data.SaveChanges();
        }

        public CourseDetailsServiceModel Details(int id)
        {
            var course = data.Courses.Include(c => c.Category).FirstOrDefault(c => c.Id == id);
            course.Category.Name = GetCategoryName(course.CategoryId);
            var topics = data.Topics.Where(t => t.CourseId == id)
                    .ProjectTo<TopicServiceModel>(queryableMapper);

            var serviceModel = mapper.Map<Course, CourseDetailsServiceModel>(course);
            serviceModel.Topics = topics;

            return serviceModel;
        }

        private Category ToCategory(CategoryServiceModel model)
                => data.Categories.FirstOrDefault(c => c.Name == model.Name);


    }
}
