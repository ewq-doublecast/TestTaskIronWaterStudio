using Microsoft.AspNetCore.Mvc;

namespace TestTaskIronWaterStudio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
