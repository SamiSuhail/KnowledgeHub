using KnowledgeHub.Services.Courses.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeHub.Models.Courses
{
    public class CourseAllQueryModel
    {
        public const int CoursesPerPage = 3;

        public string Category { get; init; }

        public string SearchTerm { get; init; }

        public CourseSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalCourses { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<CourseAllServiceModel> Courses;
    }
}
