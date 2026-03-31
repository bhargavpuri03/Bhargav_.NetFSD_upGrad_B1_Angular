using Microsoft.AspNetCore.Mvc;

namespace Assignment_7_14_.Controllers
{
    public class UserInfoController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Name"] = "John";
            ViewData["Age"] = 25;
            return View();
        }
    }
}