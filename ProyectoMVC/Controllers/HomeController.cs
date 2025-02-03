using Microsoft.AspNetCore.Mvc;

namespace ProyectoMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
