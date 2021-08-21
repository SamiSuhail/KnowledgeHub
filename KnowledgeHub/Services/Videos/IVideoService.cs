using KnowledgeHub.Services.Videos.Models;

namespace KnowledgeHub.Services.Videos
{
    public interface IVideoService
    {
        public VideoAllServiceModel AllVideos(string courseId, string topicId = null);
        public bool Add(string courseId, VideoAddServiceModel model);
    }
}
