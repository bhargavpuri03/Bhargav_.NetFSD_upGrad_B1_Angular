using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "Ashwin";      // dynamic
            ViewData["Age"] = 20;         // object

            return View();
        }
    }
}