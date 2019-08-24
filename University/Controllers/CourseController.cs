using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using University.Models;
using University.DAL.Repository;
using University.Common;

namespace University.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            var model = _courseRepository.GetCoursesWithStudents().Select(Mapper.ToView).ToList();
            return View(model);
        }
    }
}
