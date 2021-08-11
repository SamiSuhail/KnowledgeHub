using KnowledgeHub.Models.Videos;

namespace KnowledgeHub.Services.Videos
{
    public interface IVideoService
    {
        public VideoAllDisplayModel AllVideos(string courseId, string topicId);
    }
}
