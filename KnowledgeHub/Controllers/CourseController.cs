using AutoMapper;
using KnowledgeHub.Models.Courses;
using KnowledgeHub.Services.Courses;
using KnowledgeHub.Services.Courses.Models;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHub.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService courses;
        private readonly IMapper mapper;
        public CourseController(ICourseService courses, IMapper mapper)
        {
            this.courses = courses;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var allCategories = courses.AllCategories();

            return View(allCategories);
        }

        //public IActionResult All()
        //{
        //    var allCourses = courses.AllCourses();

        //    return View(allCourses);
        //}

        public IActionResult All(string category)
        {
            var allCourses = courses.AllCourses(category);

            return View(allCourses);
        }

        public IActionResult AddTopic(int id)
            => View();

        [HttpPost]
        public IActionResult AddTopic(int id, CourseAddTopicFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var serviceModel = mapper.Map<CourseAddTopicServiceModel>(model);

            var topicNameUnused = courses.AddTopic(id, serviceModel);

            if (!topicNameUnused)
            {
                return View(model);
            }
            return Redirect($"/Video/All?courseId={id}");
        }

        public IActionResult Create()
                => View(new CourseCreateFormModel() { Categories = courses.AllCategories() });

        [HttpPost]
        public IActionResult Create(CourseCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = courses.AllCategories();
                return View(model);
            }

            var serviceModel = mapper.Map<CourseCreateServiceModel>(model);

            courses.Create(serviceModel);
            return Redirect("/Course/All");
        }

        public IActionResult Details(int id)
        {
            var course = courses.Details(id);

            return View(course);
        }
    }
}
