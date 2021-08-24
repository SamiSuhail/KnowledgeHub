using AutoMapper;
using KnowledgeHub.Infrastructure;
using KnowledgeHub.Models.Courses;
using KnowledgeHub.Services.Courses;
using KnowledgeHub.Services.Courses.Models;
using KnowledgeHub.Services.Lectors;
using KnowledgeHub.Services.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static KnowledgeHub.WebConstants;

namespace KnowledgeHub.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService courses;
        private readonly IMapper mapper;
        private ILectorService lectors;
        private IStudentService students;
        public CourseController(ICourseService courses, ILectorService lectors, IStudentService students, IMapper mapper)
        {
            this.courses = courses;
            this.mapper = mapper;
            this.lectors = lectors;
            this.students = students;
        }

        public IActionResult All([FromQuery] CourseAllQueryModel query)
        {
            ViewBag.UserId = this.User.Id();

            var queryResult = this.courses.AllCourses(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                CourseAllQueryModel.CoursesPerPage);


            var courseCategories = this.courses.AllCategoriesStrings();

            query.Categories = courseCategories;
            query.TotalCourses = queryResult.TotalCourses;
            query.Courses = queryResult.Courses;

            return View(query);
        }

        [Authorize]
        public IActionResult AddTopic(int id)
        {
            if (courses.UserId(id) != this.User.Id())
            {
                TempData[WarningMessageKey] = "You cannot edit other lector's courses!";
                return RedirectToAction(nameof(CourseController.Details), "Course", new{ Id = id});
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddTopic(int id, CourseAddTopicFormModel model)
        {
            if (courses.UserId(id) != this.User.Id())
            {
                TempData[WarningMessageKey] = "You cannot edit other lector's courses!";
                return RedirectToAction(nameof(CourseController.Details), "Course", new { Id = id });
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var serviceModel = this.mapper.Map<CourseAddTopicServiceModel>(model);

            var topicNameUnused = this.courses.AddTopic(id, serviceModel);

            if (!topicNameUnused)
            {
                return View(model);
            }

            TempData[GlobalMessageKey] = "New topic added.";

            return Redirect($"/Video/All?courseId={id}");
        }

        [Authorize]
        public IActionResult Create()
        {
            if (!lectors.IsLector(this.User.Id()))
            {
                return RedirectToAction(nameof(LectorController.Become), "Lector");
            }

            return View(new CourseCreateFormModel() { Categories = this.courses.AllCategories() }); ;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CourseCreateFormModel model)
        {
            if (!lectors.IsLector(this.User.Id()))
            {
                return RedirectToAction(nameof(LectorController.Become), "Lector");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = this.courses.AllCategories();
                return View(model);
            }

            var serviceModel = this.mapper.Map<CourseCreateServiceModel>(model);
            serviceModel.LectorId = this.lectors.GetId(this.User.Id());

            courses.Create(serviceModel);

            TempData[GlobalMessageKey] = "New course added.";

            return Redirect("/Course/All");
        }

        public IActionResult Details(int id)
        {
            var userId = this.User.Id();
            var course = this.courses.Details(id);

            ViewBag.UserIsAuthorized = this.courses.UserId(id) == userId;
            ViewBag.UserIsStudent = this.students.IsStudent(userId);
            ViewBag.UserIsLector = this.lectors.IsLector(userId);

            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var userId = this.User.Id();

            if (!this.lectors.IsLector(userId))
            {
                return RedirectToAction(nameof(LectorController.Become), "Lector");
            }

            if (this.courses.UserId(id) != userId)
            {
                TempData[WarningMessageKey] = "You cannot delete other lector's courses!";
                return RedirectToAction(nameof(CourseController.Details), "Course", new { Id = id });
            }

            this.courses.Delete(id);

            TempData[GlobalMessageKey] = "Your course has been deleted permanently.";

            return RedirectToAction(nameof(CourseController.All), "Course");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var userId = this.User.Id();

            if (!this.lectors.IsLector(userId))
            {
                return RedirectToAction(nameof(LectorController.Become), "Lector");
            }

            //CourseCreateFormModel
            var course = this.mapper.Map<CourseCreateFormModel>(this.courses.DetailsForEdit(id));
            

            if (this.courses.UserId(id) != userId)
            {
                TempData[WarningMessageKey] = "You cannot edit other lector's courses!";
                return RedirectToAction(nameof(CourseController.Details), "Course", new { Id = id });
            }

            course.Categories = this.courses.AllCategories();

            if (course.ImageUrl == DefaultCourseImageUrl)
            {
                course.ImageUrl = "";
            }

            return View(course);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, CourseCreateFormModel model)
        {
            var userId = this.User.Id();
            var lectorId = this.lectors.GetId(userId);

            if (lectorId == 0)
            {
                return RedirectToAction(nameof(LectorController.Become), "Lector");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = this.courses.AllCategories();

                return View(model);
            }

            if (this.courses.UserId(id) != userId)
            {
                TempData[WarningMessageKey] = "You cannot edit other lector's courses!";
                return RedirectToAction(nameof(CourseController.Details), "Course", new { Id = id });
            }

            this.courses.Edit(id, model.Name, model.CategoryId, model.Description, model.ImageUrl);

            TempData[GlobalMessageKey] = "Course edited";

            return RedirectToAction(nameof(Details), new { Id = id});
        }
    }
}
