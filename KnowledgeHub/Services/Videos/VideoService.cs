using KnowledgeHub.Data;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Services.Courses.Models;
using KnowledgeHub.Services.Videos.Models;
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

        public bool Add(string courseId, VideoAddServiceModel model)
        {
            var topicId = data.Topics.FirstOrDefault(t => t.Name == model.Topic && t.CourseId == int.Parse(courseId)).Id;

            if (data.Videos.Where(v => v.TopicId == topicId).Any(v => v.Name == model.Name))
            {
                return false;
            }

            data.Videos.Add(new Video()
            {
                Name = model.Name,
                TopicId = topicId,
                URL = model.URL,
            });

            data.SaveChanges();
            return true;
        }

        public VideoAllServiceModel AllVideos(string courseId, string topicId = null)
        {
            var allTopics = data.Topics.Where(t => t.CourseId == int.Parse(courseId))
                    .Select(t => new TopicServiceModel
                    {
                        CourseId = t.CourseId,
                        Id = t.Id,
                        Name = t.Name,
                    }).ToList();

            var allVideos = topicId == null
                        ? data.Videos.Select(v => new VideoServiceModel()
                        {
                            Name = v.Name,
                            Url = v.URL,
                            CreatedOn = v.CreatedOn,
                        }).ToList()
                        : data.Videos.Where(v => v.TopicId == int.Parse(topicId))
                        .Select(v => new VideoServiceModel()
                        {
                            Name = v.Name,
                            Url = v.URL,
                            CreatedOn = v.CreatedOn,
                        }).ToList();

            return new VideoAllServiceModel()
            {
                Topics = allTopics,
                Videos = allVideos,
            };
        }
    }
}
