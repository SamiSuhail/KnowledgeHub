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
        public void Create(CourseCreateServiceModel model);
        public CourseDetailsServiceModel Details(int id);


    }
}
