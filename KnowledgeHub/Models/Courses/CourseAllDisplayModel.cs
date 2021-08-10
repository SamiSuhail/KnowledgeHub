using System;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeHub.Models.Courses
{
    public class CourseAllDisplayModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        public  DateTime CreatedOn { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
