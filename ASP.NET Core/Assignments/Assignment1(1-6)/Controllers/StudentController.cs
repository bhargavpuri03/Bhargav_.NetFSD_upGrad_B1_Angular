using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile(string name, int age)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            return View();
        }
    }
}