using KnowledgeHub.Models.Courses;
using KnowledgeHub.Models.Topics;
using System.Collections.Generic;

namespace KnowledgeHub.Services.Courses
{
    public interface ICourseService
    {
        public IEnumerable<CategoryDisplayModel> AllCategories();
        public IEnumerable<CourseAllDisplayModel> AllCourses(string category);
        public IEnumerable<TopicDisplayModel> AllTopics(string courseId);

        public bool AddTopic(int courseId, CourseAddTopicFormModel model);
        public void Create(CourseCreateFormModel model);
        public CourseDetailsDisplayModel Details(int id);
        public void SeedCategories();


    }
}
