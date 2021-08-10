using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static KnowledgeHub.Data.DataConstants;

namespace KnowledgeHub.Data.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CourseNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string ImageUrl { get; set; } = @"https://elearningindustry.com/wp-content/uploads/2020/01/designing-effective-elearning-courses.jpg";
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? LastModified { get; set; }
        public IEnumerable<Video> Videos { get; set; } = new List<Video>();
    }
}
