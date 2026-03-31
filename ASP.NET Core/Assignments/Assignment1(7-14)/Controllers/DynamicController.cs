using Microsoft.AspNetCore.Mvc;

namespace Assignment_7_14_.Controllers
{
    public class DynamicController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About Page";
            return View();
        }
    }
}