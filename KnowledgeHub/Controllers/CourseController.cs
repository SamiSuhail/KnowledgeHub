using KnowledgeHub.Data;
using KnowledgeHub.Models;
using KnowledgeHub.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        public IActionResult Category(string name)
        {
            return View();
        }
    }
}
