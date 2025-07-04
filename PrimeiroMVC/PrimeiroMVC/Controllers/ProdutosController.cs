using Microsoft.AspNetCore.Mvc;

namespace PrimeiroMVC.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            // Aqui você poderia buscar os detalhes do produto pelo ID
            // Por enquanto, vamos apenas retornar uma view simples
            ViewBag.ProdutoId = id;
            return View();
        }

        public IActionResult Clientes()
        {
            // Retorna a view para criar um novo produto
            return View();
        }
    }
}
