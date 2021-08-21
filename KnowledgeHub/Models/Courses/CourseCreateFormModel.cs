using KnowledgeHub.Services.Courses.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeHub.Models.Courses
{
    using static Data.DataConstants.Course;
    public class CourseCreateFormModel
    {
        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<CategoryServiceModel> Categories {get;set;}
    }
}
