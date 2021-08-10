using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeHub.Data.Models
{
    public class Topic
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public IEnumerable<Video> Videos { get; set; }
    }
}
