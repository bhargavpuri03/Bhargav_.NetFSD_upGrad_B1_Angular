using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string name, string subject)
        {
            ViewBag.Name = name;
            ViewBag.Subject = subject;
            return View();
        }
    }
}