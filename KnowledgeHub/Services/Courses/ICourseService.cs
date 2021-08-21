using KnowledgeHub.Services.Courses.Models;
using System.Collections.Generic;

namespace KnowledgeHub.Services.Courses
{
    public interface ICourseService
    {
        public IEnumerable<CategoryServiceModel> AllCategories();
        public IEnumerable<CourseAllServiceModel> AllCourses(string category);
        public IEnumerable<TopicServiceModel> AllTopics(string courseId);

        public bool AddTopic(int courseId, CourseAddTopicServiceModel model);
        public void Create(CourseCreateServiceModel model);
        public CourseDetailsServiceModel Details(int id);


    }
}
