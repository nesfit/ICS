using System.Web.Mvc;
using Calculators.Engine;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new MathematicModel());
        }

        public ActionResult Calculate(MathematicModel input)
        {
            var ui = new Calculator(input);
            return View(ui.Calculate());
        }
    }
}