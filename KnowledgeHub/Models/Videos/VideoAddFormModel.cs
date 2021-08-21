﻿using KnowledgeHub.Services.Courses.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static KnowledgeHub.Data.DataConstants;

namespace KnowledgeHub.Models.Videos
{
    public class VideoAddFormModel
    {
        [Required]
        [MaxLength(VideoNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string URL { get; set; }

        public string Topic { get; set; }
        public IEnumerable<TopicServiceModel> Topics { get; set; }

    }
}
