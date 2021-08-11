using KnowledgeHub.Models.Videos;

namespace KnowledgeHub.Services.Videos
{
    public interface IVideoService
    {
        public VideoAllDisplayModel AllVideos(string courseId, string topicId = null);
        public bool Add(string courseId, VideoAddFormModel model);
    }
}
