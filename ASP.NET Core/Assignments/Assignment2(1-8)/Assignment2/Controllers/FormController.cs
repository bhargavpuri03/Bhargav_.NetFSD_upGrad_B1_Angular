using Microsoft.AspNetCore.Mvc;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class FormController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Form submitted successfully!";
            }

            return View(student);
        }
    }
}