using System.Collections.Generic;

namespace KnowledgeHub.Services.Courses.Models
{
    public class CourseCreateServiceModel
    {
        public int LectorId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
    }
}
