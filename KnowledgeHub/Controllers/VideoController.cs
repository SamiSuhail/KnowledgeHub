using AutoMapper;
using KnowledgeHub.Infrastructure;
using KnowledgeHub.Models.Videos;
using KnowledgeHub.Services.Courses;
using KnowledgeHub.Services.Students;
using KnowledgeHub.Services.Videos;
using KnowledgeHub.Services.Videos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static KnowledgeHub.WebConstants;

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

            ViewBag.UserIsAuthorized = this.courses.UserId(courseId) == this.User.Id();
            ViewBag.TopicDescription = topicId != null
                                  ? this.courses.GetTopicDescription(topicId)
                                  : "";

            return View(videos.AllVideos(courseId, topicId));
        } 

        [Authorize]
        public IActionResult Add(int courseId)
        {
            if (courses.UserId(courseId) != this.User.Id())
            {
                TempData[WarningMessageKey] = "You cannot edit other lector's courses!";
                return RedirectToAction(nameof(CourseController.Details), "Course", new { Id = courseId });
            }

            return View(new VideoAddFormModel() { Topics = videos.AllVideos(courseId).Topics });
        }


        [HttpPost]
        [Authorize]
        public IActionResult Add(int courseId, VideoAddFormModel model)
        {
            if (courses.UserId(courseId) != this.User.Id())
            {
                TempData[WarningMessageKey] = "You cannot edit other lector's courses!";
                return RedirectToAction(nameof(CourseController.Details), "Course", new { Id = courseId });
            }

            if (!ModelState.IsValid)
            {
                model.Topics = this.videos.AllVideos(courseId).Topics;
                return View(model);
            }

            var serviceModel = this.mapper.Map<VideoAddFormModel, VideoAddServiceModel>(model);

            var videoNameUnused = this.videos.Add(courseId, serviceModel);

            if (!videoNameUnused)
            {
                model.Topics = this.videos.AllVideos(courseId).Topics;
                return View(model);
            }

            TempData[GlobalMessageKey] = "New video added.";

            return Redirect($"/Video/All?courseId={courseId}");
        }

    }
}
