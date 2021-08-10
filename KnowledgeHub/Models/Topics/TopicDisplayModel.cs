using KnowledgeHub.Models.Videos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeHub.Models.Topics
{
    public class TopicDisplayModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<VideoDisplayModel> Videos { get; set; }
    }
}
