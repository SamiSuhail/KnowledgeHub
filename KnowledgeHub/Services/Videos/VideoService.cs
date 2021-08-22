using AutoMapper;
using AutoMapper.QueryableExtensions;
using KnowledgeHub.Data;
using KnowledgeHub.Data.Models;
using KnowledgeHub.Services.Courses.Models;
using KnowledgeHub.Services.Videos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KnowledgeHub.Services.Videos
{
    public class VideoService : IVideoService
    {
        private KnowledgeHubDbContext data;
        private readonly IMapper mapper;
        private readonly IConfigurationProvider queryableMapper;
        public VideoService(KnowledgeHubDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
            this.queryableMapper = mapper.ConfigurationProvider;
        }

        public bool Add(int courseId, VideoAddServiceModel model)
        {
            var topicId = data.Topics.FirstOrDefault(t => t.Id == model.TopicId && t.CourseId == courseId).Id;

            if (data.Videos.Where(v => v.TopicId == topicId).Any(v => v.Name == model.Name))
            {
                return false;
            }

            var video = mapper.Map<VideoAddServiceModel, Video>(model);

            data.Videos.Add(video);

            data.SaveChanges();
            return true;
        }

        public VideoAllServiceModel AllVideos(int courseId, int? topicId = null)
        {
            var allTopics = data.Topics.Where(t => t.CourseId == courseId)
                .ProjectTo<TopicServiceModel>(queryableMapper)
                .ToList();

            var allVideos = topicId == null
                        ? data.Videos.ProjectTo<VideoServiceModel>(queryableMapper)
                        .ToList()
                        : data.Videos.Where(v => v.TopicId == topicId)
                        .ProjectTo<VideoServiceModel>(queryableMapper)
                        .ToList();

            return new VideoAllServiceModel()
            {
                Topics = allTopics,
                Videos = allVideos,
            };
        }
    }
}
