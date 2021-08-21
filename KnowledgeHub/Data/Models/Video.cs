using System;
using System.ComponentModel.DataAnnotations;

using static KnowledgeHub.Data.DataConstants;

namespace KnowledgeHub.Data.Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(VideoNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public int TopicId { get; set; }
        public Topic Topic { get; set; }

    }
}
