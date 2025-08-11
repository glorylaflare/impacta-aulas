using Microsoft.AspNetCore.Mvc;

namespace BibliotecaTreino.Controllers
{
    public class AutoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
