using Microsoft.AspNetCore.Mvc;

namespace CdApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Startsida där text skrivs ut med ViewBag
            ViewBag.Start = "Välkommen till min CD-samling!";
            return View();
        }
    }
}
