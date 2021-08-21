using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static KnowledgeHub.Data.DataConstants.Course;

namespace KnowledgeHub.Data.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? LastModified { get; set; }
        public IEnumerable<Topic> Topics { get; set; } = new List<Topic>();

        public int LectorId { get; set; }
        public Lector Lector { get; set; }
    }
}
