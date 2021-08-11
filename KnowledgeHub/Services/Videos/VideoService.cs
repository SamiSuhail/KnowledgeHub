using KnowledgeHub.Data;
using KnowledgeHub.Models.Topics;
using KnowledgeHub.Models.Videos;
using KnowledgeHub.Services.Courses;
using System.Linq;

namespace KnowledgeHub.Services.Videos
{
    public class VideoService : IVideoService
    {
        private KnowledgeHubDbContext data;
        public VideoService(KnowledgeHubDbContext data)
        {
            this.data = data;
        }

        public VideoAllDisplayModel AllVideos(string courseId, string topicId)
        {
            var allTopics = data.Topics.Where(t => t.CourseId == int.Parse(courseId))
                    .Select(t => new TopicDisplayModel 
                    { 
                        CourseId = t.CourseId,
                        Id = t.Id,
                        Name = t.Name,
                    }).ToList();
            var allVideos = data.Videos.Where(v => v.TopicId == int.Parse(topicId))
                    .Select(v => new VideoDisplayModel()
                    {
                        Name = v.Name,
                        Url = v.URL,
                        CreatedOn = v.CreatedOn,
                    }).ToList();

            return new VideoAllDisplayModel() 
            {
                Topics = allTopics,
                Videos = allVideos,
            };
        }
    }
}
