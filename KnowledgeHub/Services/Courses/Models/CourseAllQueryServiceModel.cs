using System.Collections.Generic;

namespace KnowledgeHub.Services.Courses.Models
{
    public class CourseAllQueryServiceModel
    {

        public int TotalCourses { get; set; }
        public int CurrentPage { get; set; }
        public int CoursesPerPage { get; set; }
        public IEnumerable<CourseAllServiceModel> Courses { get; set; }
    }
}
