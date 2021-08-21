using KnowledgeHub.Services.Courses.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeHub.Models.Courses
{
    using static Data.DataConstants;
    public class CourseCreateFormModel
    {
        [Required]
        [MaxLength(CourseNameMaxLength)]
        [MinLength(CourseNameMinLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(CourseDescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<CategoryServiceModel> Categories {get;set;}
    }
}
