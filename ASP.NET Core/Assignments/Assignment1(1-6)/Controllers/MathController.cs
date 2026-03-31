using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class MathController : Controller
    {
        public IActionResult Add(int a, int b)
        {
            int result = a + b;
            ViewBag.Result = result;
            ViewBag.Operation = "Addition";
            return View("Result");
        }

        public IActionResult Multiply(int a, int b)
        {
            int result = a * b;
            ViewBag.Result = result;
            ViewBag.Operation = "Multiplication";
            return View("Result");
        }
    }
}