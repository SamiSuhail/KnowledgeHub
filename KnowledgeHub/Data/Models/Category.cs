using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeHub.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public IEnumerable<Course> Courses { get; set; } = new List<Course>();
    }
}
