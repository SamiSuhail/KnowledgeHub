using System;
using System.ComponentModel.DataAnnotations;

using static KnowledgeHub.Data.DataConstants;

namespace KnowledgeHub.Models.Videos
{
    public class VideoDisplayModel
    {
        [Required]
        [MaxLength(VideoNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
