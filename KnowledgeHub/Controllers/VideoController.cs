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

        public IActionResult All(string courseId, string topicId)
        => View(videos.AllVideos(courseId, topicId));

    }
}
