using System.ComponentModel.DataAnnotations;

using static KnowledgeHub.Data.DataConstants.Topic;

namespace KnowledgeHub.Models.Topics
{
    public class TopicDisplayModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string Name { get; set; }
    }
}
