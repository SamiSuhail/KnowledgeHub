using KnowledgeHub.Models.Course;
using System.Collections.Generic;

namespace KnowledgeHub.Services
{
    public interface ICourseService
    {
        public IEnumerable<CourseCategoryDisplayModel> AllCategories();
        public IEnumerable<CourseAllDisplayModel> AllCourses(string category);
        public void Create(CourseCreateFormModel model);
        public void SeedCategories();
    }
}
