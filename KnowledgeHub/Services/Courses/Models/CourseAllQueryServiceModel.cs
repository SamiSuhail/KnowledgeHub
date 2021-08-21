using KnowledgeHub.Services.Courses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
