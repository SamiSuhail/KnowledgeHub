using KnowledgeHub.Services.Courses.Models;
using System.Collections.Generic;

namespace KnowledgeHub.Services.Videos.Models
{
    public class VideoAddServiceModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public int TopicId { get; set; }
        //public IEnumerable<TopicServiceModel> Topics { get; set; }
    }
}
