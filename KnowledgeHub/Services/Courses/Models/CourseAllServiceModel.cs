using System;

namespace KnowledgeHub.Services.Courses.Models
{
    public class CourseAllServiceModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedOn { get; set; }

        public string ImageUrl { get; set; }
    }
}
