using System.Linq;
using Microsoft.AspNetCore.Mvc;
using University.Models;
using University.DAL.Repository;
using University.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace University.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentController(IStudentRepository studentRepository, ICourseRepository courseRepository )
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        private void SetCourseViewBag(int? CourseId = null)
        {

            if (CourseId == null)
                ViewBag.CourseId = new SelectList(_courseRepository.GetCourses(), "Id", "Name");
            else
                ViewBag.CourseId = new SelectList(_courseRepository.GetCourses(), "Id", "Name", CourseId);
        }

        public IActionResult Index()
        {
            var model = _courseRepository.GetCoursesWithStudents().Select(Mapper.ToView).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create(int courseId)
        {
            SetCourseViewBag(courseId);
            return View("CreateEdit", new StudentModel());
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult Create(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Insert(Mapper.ToDomain(model));
                return RedirectToAction("Index");
            }

            SetCourseViewBag();
            return View("CreateEdit", model);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var student = _studentRepository.Find(id);
            StudentModel model = Mapper.ToView(student);
            SetCourseViewBag(student.CourseId);
            return View("CreateEdit", model);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Update(Mapper.ToDomain(model));
                return RedirectToAction("Index");
            }
            SetCourseViewBag();
            return View("CreateEdit", model);
        }

        public IActionResult Delete(int id)
        {
            _studentRepository.Delete(_studentRepository.Find(id));
            return RedirectToAction("Index", "Student");

        }
    }
}
