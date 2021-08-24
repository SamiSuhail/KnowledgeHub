using KnowledgeHub.Services.Courses.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static KnowledgeHub.Data.DataConstants.Course;

namespace KnowledgeHub.Models.Courses
{
    public class CourseCreateFormModel
    {
        [Required]
        [MaxLength(NameMaxLength, ErrorMessage = "Name can be mostly 30 symbols.")]
        [MinLength(NameMinLength, ErrorMessage = "Name should be at least 5 symbols.")]
        public string Name { get; set; }

        [Required]
        [MinLength(DescriptionMinLength, ErrorMessage = "Description should be at least 30 symbols.")]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        public IEnumerable<CategoryServiceModel> Categories {get;set;}
    }
}
