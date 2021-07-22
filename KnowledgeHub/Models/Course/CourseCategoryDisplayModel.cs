using System.ComponentModel.DataAnnotations;

namespace KnowledgeHub.Models.Course
{
    public class CourseCategoryDisplayModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
