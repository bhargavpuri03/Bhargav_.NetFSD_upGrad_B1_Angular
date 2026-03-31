using Microsoft.AspNetCore.Mvc;

namespace Assignment_7_14_.Controllers
{
    public class DateController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Current Date";
            return View();
        }
    }
}