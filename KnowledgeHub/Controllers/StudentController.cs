using AutoMapper;
using KnowledgeHub.Infrastructure;
using KnowledgeHub.Models.Students;
using KnowledgeHub.Services.Students;
using KnowledgeHub.Services.Students.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeHub.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService students;
        private readonly IMapper mapper;

        public StudentController(IStudentService students, IMapper mapper)
        {
            this.students = students;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult Become() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeStudentFormModel model)
        {
            var userId = this.User.Id();


            if (students.IsStudent(userId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var serviceModel = mapper.Map<BecomeStudentFormModel, BecomeStudentServiceModel>(model);
            serviceModel.UserId = userId;

            students.Become(serviceModel);

            return RedirectToAction(nameof(CourseController.All), "Course");
        }
    }
}
