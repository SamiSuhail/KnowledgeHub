using AutoMapper;
using KnowledgeHub.Infrastructure;
using KnowledgeHub.Models.Lectors;
using KnowledgeHub.Services.Lectors;
using KnowledgeHub.Services.Lectors.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeHub.Controllers
{
    public class LectorController : Controller
    {
        private ILectorService lectors;
        private IMapper mapper;
        public LectorController(ILectorService lectors, IMapper mapper)
        {
            this.lectors = lectors;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult Become() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeLectorFormModel model)
        {
            var userId = this.User.Id();

            
            if (lectors.IsLector(userId))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var serviceModel = this.mapper.Map<BecomeLectorFormModel, BecomeLectorServiceModel>(model);
            serviceModel.UserId = userId;

            lectors.Become(serviceModel);

            return RedirectToAction(nameof(CourseController.All), "Course");
        }
    }
}
