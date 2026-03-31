using Microsoft.AspNetCore.Mvc;
using Assignment_7_14_.Models;

namespace Assignment_7_14_.Controllers
{
    public class StudentStrongController : Controller
    {
        public IActionResult Index()
        {
            // Create a student object
            Student student = new Student
            {
                Name = "Alice",
                Age = 20
            };

            ViewData["Title"] = "Student Strongly Typed View";

            // Pass student to view
            return View(student);
        }
    }
}