using System;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeHub.Models.Course
{
    public class CourseAllDisplayModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        public DateTime? LastModified { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
