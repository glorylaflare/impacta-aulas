using Microsoft.AspNetCore.Mvc;

namespace BibliotecaTreino.Controllers
{
    public class EmprestimosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
