using KnowledgeHub.Services.Courses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeHub.Services.Videos.Models
{
    public class VideoAllServiceModel
    {
        public IEnumerable<VideoServiceModel> Videos { get; set; }

        public IEnumerable<TopicServiceModel> Topics { get; set; }
    }
}
