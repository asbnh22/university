using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
