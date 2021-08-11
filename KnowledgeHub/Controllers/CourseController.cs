using KnowledgeHub.Models.Courses;
using KnowledgeHub.Services.Courses;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHub.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService courses;
        public CourseController(ICourseService courses)
        {
            this.courses = courses;
        }
        public IActionResult Index()
        {
            courses.SeedCategories();
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

            courses.AddTopic(id, model);
            return Redirect($"/Video/All?courseId={id}");
        }

        public IActionResult AllTopics(string courseId)
        => View(courses.AllTopics(courseId));

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

            courses.Create(model);
            return Redirect("/Course/All");
        }

        public IActionResult Details(int id)
        {
            var course = courses.Details(id);

            return View(course);
        }
    }
}
