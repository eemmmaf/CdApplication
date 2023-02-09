using Microsoft.AspNetCore.Mvc;

namespace CdApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Startsida
            return View();
        }
    }
}
