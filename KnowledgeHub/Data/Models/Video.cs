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
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? LastModified { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
