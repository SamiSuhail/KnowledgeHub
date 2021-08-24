using System.ComponentModel.DataAnnotations;

using static KnowledgeHub.Data.DataConstants.Topic;

namespace KnowledgeHub.Models.Courses
{
    public class CourseAddTopicFormModel
    {
        [Required]
        [MaxLength(NameMaxLength, ErrorMessage = "Name can be mostly 20 symbols.")]
        [MinLength(NameMinLength, ErrorMessage = "Name should be at least 1 symbol.")]
        public string Name { get; set; }

        [Required]
        [MinLength(DescriptionMinLength, ErrorMessage = "Description should be at least 30 symbols.")]
        public string Description { get; set; }
    }
}
