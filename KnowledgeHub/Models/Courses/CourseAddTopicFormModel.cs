using System.ComponentModel.DataAnnotations;

namespace KnowledgeHub.Models.Courses
{
    public class CourseAddTopicFormModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
