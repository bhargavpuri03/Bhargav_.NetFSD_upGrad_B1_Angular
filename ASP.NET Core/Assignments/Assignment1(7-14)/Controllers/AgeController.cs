using Microsoft.AspNetCore.Mvc;

namespace Assignment_7_14_.Controllers
{
    public class AgeController : Controller
    {
        public IActionResult Index(int age = 16) // default age = 16
        {
            ViewData["Title"] = "Age Eligibility";
            ViewBag.Age = age;
            return View();
        }
    }
}