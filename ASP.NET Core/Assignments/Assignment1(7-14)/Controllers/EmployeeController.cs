using Microsoft.AspNetCore.Mvc;

namespace Assignment_7_14_.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Details()
        {
            ViewData["Name"] = "Alice";
            ViewData["Salary"] = 50000;
            ViewData["Department"] = "IT";

            return View();
        }
    }
}