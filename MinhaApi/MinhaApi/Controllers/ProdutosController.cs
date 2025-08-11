using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;

namespace MinhaApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
    // Lista em memória para simular um banco de dados
    private static readonly List<Produto> _produtos = new List<Produto>
    {
        new Produto { Id = 1, Nome = "Notebook Gamer", Preco = 7500.50m },
        new Produto { Id = 2, Nome = "Mouse Vertical", Preco = 350.00m },
        new Produto { Id = 3, Nome = "Teclado Mecânico", Preco = 550.75m }
    };

    // GET: api/produtos
    [HttpGet]
    public ActionResult<IEnumerable<Produto>> GetProdutos()
    {
        return Ok(_produtos);
    }
}
