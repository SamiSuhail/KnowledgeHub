using KnowledgeHub.Data;
using KnowledgeHub.Models.Course;
using KnowledgeHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHub.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService courses;
        public CourseController(ICourseService courses, KnowledgeHubDbContext data)
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
    }
}
