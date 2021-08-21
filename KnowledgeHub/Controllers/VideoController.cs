using AutoMapper;
using KnowledgeHub.Models.Videos;
using KnowledgeHub.Services.Videos;
using KnowledgeHub.Services.Videos.Models;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHub.Controllers
{
    public class VideoController : Controller
    {
        private IVideoService videos;
        private readonly IMapper mapper;
        public VideoController(IVideoService videos, IMapper mapper)
        {
            this.videos = videos;
            this.mapper = mapper;
        }

        public IActionResult All(string courseId, string topicId = null)
            => View(videos.AllVideos(courseId, topicId));

        public IActionResult Add(string courseId)
                => View(new VideoAddFormModel() { Topics = videos.AllVideos(courseId).Topics });

        [HttpPost]
        public IActionResult Add(string courseId, VideoAddFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Topics = videos.AllVideos(courseId).Topics;
                return View(model);
            }

            var serviceModel = mapper.Map<VideoAddFormModel, VideoAddServiceModel>(model);

            var videoNameUnused = videos.Add(courseId, serviceModel);

            if (!videoNameUnused)
            {
                model.Topics = videos.AllVideos(courseId).Topics;
                return View(model);
            }

            return Redirect($"/Video/All?courseId={courseId}");
        }

    }
}
