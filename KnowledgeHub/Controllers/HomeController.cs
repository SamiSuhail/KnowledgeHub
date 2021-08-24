using KnowledgeHub.Infrastructure;
using KnowledgeHub.Models;
using KnowledgeHub.Services.Courses;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KnowledgeHub.Controllers
{
    public class HomeController : Controller
    {
        private ICourseService courses;
        public HomeController(ICourseService courses)
        {
            this.courses = courses;
        }
        public IActionResult Index()
        {
            var allCategories = this.courses.AllCategories();
            ViewBag.UserIsLogged = this.User.IsLogged();

            return View(allCategories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        
    }
}
