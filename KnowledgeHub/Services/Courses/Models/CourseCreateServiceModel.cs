using System.Collections.Generic;

namespace KnowledgeHub.Services.Courses.Models
{
    public class CourseCreateServiceModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<CategoryServiceModel> Categories { get; set; }
    }
}
