using Microsoft.AspNetCore.Mvc;

namespace BibliotecaTreino.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
