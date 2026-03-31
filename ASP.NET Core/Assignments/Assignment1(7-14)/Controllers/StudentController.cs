using Microsoft.AspNetCore.Mvc;

namespace Assignment_7_14_.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Details()
        {
            ViewData["Name"] = "Ashwin";
            ViewData["Age"] = 16;
            return View();
        }
    }
}