using KnowledgeHub.Models.Topics;
using System.Collections.Generic;

namespace KnowledgeHub.Models.Videos
{
    public class VideoAllDisplayModel
    {
        public IEnumerable<VideoDisplayModel> Videos { get; set; }

        public IEnumerable<TopicDisplayModel> Topics { get; set; }
    }
}
