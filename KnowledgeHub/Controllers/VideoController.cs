using KnowledgeHub.Models.Videos;
using KnowledgeHub.Services.Courses;
using KnowledgeHub.Services.Videos;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHub.Controllers
{
    public class VideoController : Controller
    {
        private IVideoService videos;
        private ICourseService courses;
        public VideoController(IVideoService videos, ICourseService courses)
        {
            this.videos = videos;
            this.courses = courses;
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

            var videoNameUnused = videos.Add(courseId, model);

            if (!videoNameUnused)
            {
                model.Topics = videos.AllVideos(courseId).Topics;
                return View(model);
            }

            return Redirect($"/Video/All?courseId={courseId}");
        }

    }
}
