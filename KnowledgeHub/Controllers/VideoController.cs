using AutoMapper;
using KnowledgeHub.Infrastructure;
using KnowledgeHub.Models.Videos;
using KnowledgeHub.Services.Courses;
using KnowledgeHub.Services.Students;
using KnowledgeHub.Services.Videos;
using KnowledgeHub.Services.Videos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHub.Controllers
{
    public class VideoController : Controller
    {
        private IVideoService videos;
        private ICourseService courses;
        private IStudentService students;
        private readonly IMapper mapper;
        public VideoController(IVideoService videos, ICourseService courses, IStudentService students, IMapper mapper)
        {
            this.videos = videos;
            this.courses = courses;
            this.students = students;
            this.mapper = mapper;
        }

        public IActionResult All(int courseId, int? topicId = null)
        {
            if (!students.IsStudent(this.User.Id()))
            {
                return RedirectToAction(nameof(StudentController.Become), "Student");
            }

            ViewBag.UserIsAuthorized = courses.UserId(courseId) == this.User.Id();

            return View(videos.AllVideos(courseId, topicId));
        } 

        [Authorize]
        public IActionResult Add(int courseId)
        {
            if (courses.UserId(courseId) != this.User.Id())
            {
                return Unauthorized();
            }

            return View(new VideoAddFormModel() { Topics = videos.AllVideos(courseId).Topics });
        }


        [HttpPost]
        [Authorize]
        public IActionResult Add(int courseId, VideoAddFormModel model)
        {
            if (courses.UserId(courseId) != this.User.Id())
            {
                return Unauthorized();
            }

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
