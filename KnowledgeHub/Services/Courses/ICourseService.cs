using KnowledgeHub.Models.Courses;
using KnowledgeHub.Services.Courses.Models;
using System.Collections.Generic;

namespace KnowledgeHub.Services.Courses
{
    public interface ICourseService
    {
        public IEnumerable<CategoryServiceModel> AllCategories();
        public IEnumerable<string> AllCategoriesStrings();
        public CourseAllQueryServiceModel AllCourses(
            string category = null,
            string searchTerm = null,
            CourseSorting sorting = CourseSorting.CreatedOn,
            int currentPage = 1,
            int coursesPerPage = int.MaxValue);
        public IEnumerable<TopicServiceModel> AllTopics(string courseId);

        public bool AddTopic(int courseId, CourseAddTopicServiceModel model);
        public string GetTopicDescription(int? topicId);
        public void Create(CourseCreateServiceModel model);
        public void Delete(int id);
        public CourseDetailsServiceModel Details(int id);
        public CourseCreateServiceModel DetailsForEdit(int id);
        public void Edit(int id, string name, int categoryId, string description, string imageUrl);
        public string UserId(int courseId);
    }
}
