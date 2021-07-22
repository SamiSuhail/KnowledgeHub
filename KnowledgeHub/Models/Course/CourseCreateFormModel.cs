using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeHub.Models.Course
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

        public IEnumerable<CourseCategoryDisplayModel> Categories {get;set;}
    }
}
