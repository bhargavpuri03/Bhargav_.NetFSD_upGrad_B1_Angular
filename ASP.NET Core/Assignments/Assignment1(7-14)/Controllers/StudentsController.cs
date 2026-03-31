using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Assignment_7_14_.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Student List";

            // Passing a simple list of student names
            List<string> students = new List<string>
            {
                "Alice",
                "Bob",
                "Charlie",
                "David",
                "Eve"
            };

            ViewBag.Students = students;
            return View();
        }
    }
}