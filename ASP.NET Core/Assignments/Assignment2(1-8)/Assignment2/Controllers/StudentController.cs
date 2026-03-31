using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var student = new Student
            {
                Id = 1,
                Name = "Ashwin",
                Age = 20,
                Email = "ashwin@test.com"
            };

            return View(student);
        }
    }
}