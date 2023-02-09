using Microsoft.AspNetCore.Mvc;

namespace CdApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Start = "Välkommen till min CD-samling!";
            //Startsida
            return View();
        }
    }
}
