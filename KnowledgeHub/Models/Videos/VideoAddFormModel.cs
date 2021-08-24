using KnowledgeHub.Services.Courses.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static KnowledgeHub.Data.DataConstants.Video;

namespace KnowledgeHub.Models.Videos
{
    public class VideoAddFormModel
    {
        [Required]
        [MaxLength(NameMaxLength,ErrorMessage = "Name can be mostly 30 symbols.")]
        [MinLength(NameMinLength, ErrorMessage = "Name should be at least 5 symbols.")]
        public string Name { get; set; }

        [Required]
        [Url]
        [Display(Name = "URL")]
        public string Url { get; set; }

        [Required]
        public string TopicId { get; set; }
        public IEnumerable<TopicServiceModel> Topics { get; set; }

    }
}
