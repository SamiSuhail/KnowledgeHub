using AutoMapper;
using AutoMapper.QueryableExtensions;
using KnowledgeHub.Data;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Models.Courses;
using KnowledgeHub.Services.Courses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using static KnowledgeHub.WebConstants;

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
            => this.data.Categories
            .ProjectTo<CategoryServiceModel>(this.queryableMapper)
            .ToList();

        public IEnumerable<string> AllCategoriesStrings()
            => this.data.Categories
            .Select(c => c.Name)
            .ToList();

        private string GetCategoryName(int id)
            => this.data.Categories.FirstOrDefault(c => c.Id == id).Name;


        public CourseAllQueryServiceModel AllCourses(
            string category = null,
            string searchTerm = null,
            CourseSorting sorting = CourseSorting.CreatedOn,
            int currentPage = 1,
            int coursesPerPage = int.MaxValue)
        {
            var coursesQuery = this.data.Courses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                coursesQuery = coursesQuery.Where(c => c.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                coursesQuery = coursesQuery.Where(c =>
                    (c.Name).ToLower().Contains(searchTerm.ToLower()) ||
                    c.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            coursesQuery = sorting switch
            {
                CourseSorting.Name => coursesQuery.OrderByDescending(c => c.Name),
                CourseSorting.CreatedOn or _ => coursesQuery.OrderByDescending(c => c.Id)
            };

            var totalCourses = coursesQuery.Count();

            var courses = GetCourses(coursesQuery);

            foreach (var course in courses)
            {
                course.UserId = UserId(course.Id);
            }

            return new CourseAllQueryServiceModel
            {
                TotalCourses = totalCourses,
                CurrentPage = currentPage,
                CoursesPerPage = coursesPerPage,
                Courses = courses
            };
        }

        public IEnumerable<TopicServiceModel> AllTopics(string courseId)
            => this.data.Topics.Where(t => t.CourseId.ToString() == courseId)
            .ProjectTo<TopicServiceModel>(this.queryableMapper);


        public bool AddTopic(int courseId, CourseAddTopicServiceModel model)
        {
            if (this.data.Topics.Where(t => t.CourseId == courseId).Any(t => t.Name == model.Name))
            {
                return false;
            }

            var topic = this.mapper.Map<CourseAddTopicServiceModel, Topic>(model);
            topic.CourseId = courseId;

            this.data.Topics.Add(topic);

            this.UpdateLastModified(courseId);

            this.data.SaveChanges();
            return true;
        }

        public string GetTopicDescription(int? topicId)
            => this.data.Topics.FirstOrDefault(t => t.Id == topicId).Description;
        public void Create(CourseCreateServiceModel model)
        {

            var newCourse = this.mapper.Map<CourseCreateServiceModel, Course>(model);


            if (model.ImageUrl == null)
            {
                newCourse.ImageUrl = DefaultCourseImageUrl;
            }

            this.data.Courses.Add(newCourse);
            this.data.SaveChanges();
        }

        public void Delete(int id)
        {
            var course = this.data.Courses.FirstOrDefault(c => c.Id == id);

            this.data.Courses.Remove(course);
            this.data.SaveChanges();
        }
        public CourseDetailsServiceModel Details(int id)
        {
            var course = this.data.Courses
                .Include(c => c.Category)
                .FirstOrDefault(c => c.Id == id);

            var topics = this.data.Topics
                .Where(t => t.CourseId == id)
                .ProjectTo<TopicServiceModel>(this.queryableMapper)
                .ToList();

            var serviceModel = this.mapper.Map<Course, CourseDetailsServiceModel>(course);
            

            return serviceModel;
        }

        public CourseCreateServiceModel DetailsForEdit(int id)
        {
            var course = data.Courses
                .Include(c => c.Category)
                .FirstOrDefault(c => c.Id == id);

            return mapper.Map<Course, CourseCreateServiceModel>(course);
        }

        public void Edit(int id, string name, int categoryId, string description, string imageUrl)
        {
            var course = this.data.Courses.FirstOrDefault(c => c.Id == id);

            course.Name = name;
            course.CategoryId = categoryId;
            course.Description = description;
            course.ImageUrl = imageUrl == null ? DefaultCourseImageUrl : imageUrl;

            this.UpdateLastModified(id);
            this.data.SaveChanges();
        }

        private IEnumerable<CourseAllServiceModel> GetCourses(IQueryable<Course> courseQuery)
            => courseQuery
                    .ProjectTo<CourseAllServiceModel>(this.queryableMapper)
                    .ToList();

        private void UpdateLastModified(int courseId)
            => this.data.Courses
            .FirstOrDefault(c => c.Id == courseId)
            .LastModified = DateTime.UtcNow;

        public string UserId(int courseId)
            => this.data.Courses
                .Where(c => c.Id == courseId)
                .Include(c => c.Lector)
                .Select(c => c.Lector.UserId)
                .FirstOrDefault();
    }
}
