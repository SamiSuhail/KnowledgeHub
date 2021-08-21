using KnowledgeHub.Services.Courses.Models;
using System.Collections.Generic;

namespace KnowledgeHub.Services.Videos.Models
{
    public class VideoAllServiceModel
    {
        public IEnumerable<VideoServiceModel> Videos { get; set; }

        public IEnumerable<TopicServiceModel> Topics { get; set; }
    }
}
