using KnowledgeHub.Services.Courses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeHub.Services.Videos.Models
{
    public class VideoAddServiceModel
    {
        public string Name { get; set; }

        public string URL { get; set; }

        public string Topic { get; set; }
        public IEnumerable<TopicServiceModel> Topics { get; set; }
    }
}
