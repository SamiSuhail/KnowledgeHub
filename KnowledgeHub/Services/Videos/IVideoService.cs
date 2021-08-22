using KnowledgeHub.Services.Videos.Models;

namespace KnowledgeHub.Services.Videos
{
    public interface IVideoService
    {
        public VideoAllServiceModel AllVideos(int courseId, int? topicId = null);
        public bool Add(int courseId, VideoAddServiceModel model);
    }
}
