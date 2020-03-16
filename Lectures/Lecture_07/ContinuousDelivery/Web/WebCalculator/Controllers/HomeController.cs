using System.Diagnostics;
using Calculators.Engine;
using Microsoft.AspNetCore.Mvc;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new MathematicModel());
        }

        public ActionResult Calculate(MathematicModel input)
        {
            var ui = new Calculator(input);
            return View(ui.Calculate());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
