using System.ComponentModel.DataAnnotations;

namespace KnowledgeHub.Models.Topics
{
    public class TopicDisplayModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
