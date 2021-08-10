using KnowledgeHub.Models.Topics;
using KnowledgeHub.Services.Courses;
using KnowledgeHub.Services.Videos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult All(string courseId)
        {
            var topics = courses.AllTopics(courseId);

            var topicsDisplayModel = new List<TopicDisplayModel>();

            return View(topicsDisplayModel);
        }
    }
}
