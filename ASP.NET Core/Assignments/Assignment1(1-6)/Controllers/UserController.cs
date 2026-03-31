using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Details(string name, int age)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            return View();
        }
    }
}