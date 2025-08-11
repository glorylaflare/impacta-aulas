using Microsoft.AspNetCore.Mvc;

namespace BibliotecaTreino.Controllers
{
    public class LivrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
