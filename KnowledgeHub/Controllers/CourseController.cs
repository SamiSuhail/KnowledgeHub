﻿using AutoMapper;
using KnowledgeHub.Infrastructure;
using KnowledgeHub.Models.Courses;
using KnowledgeHub.Services.Courses;
using KnowledgeHub.Services.Courses.Models;
using KnowledgeHub.Services.Lectors;
using KnowledgeHub.Services.Students;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            var allCategories = courses.AllCategories();
            ViewBag.UserIsLogged = this.User.IsLogged();

            return View(allCategories);
        }

        //public IActionResult All()
        //{
        //    var allCourses = courses.AllCourses();

        //    return View(allCourses);
        //}

        public IActionResult All([FromQuery] CourseAllQueryModel query)
        {
            var queryResult = courses.AllCourses(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                CourseAllQueryModel.CoursesPerPage);

            var courseCategories = courses.AllCategoriesStrings();

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
                return Unauthorized();
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddTopic(int id, CourseAddTopicFormModel model)
        {
            if (courses.UserId(id) != this.User.Id())
            {
                return Unauthorized();
            }

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

        [Authorize]
        public IActionResult Create()
        {
            if (!lectors.IsLector(this.User.Id()))
            {
                return RedirectToAction(nameof(LectorController.Become), "Lector");
            }

            return View(new CourseCreateFormModel() { Categories = courses.AllCategories() }); ;
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
                model.Categories = courses.AllCategories();
                return View(model);
            }

            var serviceModel = mapper.Map<CourseCreateServiceModel>(model);
            serviceModel.LectorId = lectors.GetId(this.User.Id());

            courses.Create(serviceModel);
            return Redirect("/Course/All");
        }

        public IActionResult Details(int id)
        {
            var userId = this.User.Id();
            var course = courses.Details(id);

            ViewBag.UserIsAuthorized = courses.UserId(id) == userId;
            ViewBag.UserIsStudent = students.IsStudent(userId);
            ViewBag.UserIsLector = lectors.IsLector(userId);

            return View(course);
        }
    }
}
