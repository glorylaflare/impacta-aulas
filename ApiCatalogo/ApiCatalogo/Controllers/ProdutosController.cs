using ApiCatalogo.Data;
using ApiCatalogo.Model;
using ApiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogo.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProdutosController : ControllerBase
{
    public readonly IRepository _repository;

    public ProdutosController(IRepository repository)
    {
        _repository = repository;
    }
    /*
    [HttpGet("first")] // There is a difference between calling "first" and "/first"
    public async Task<ActionResult<Produto>> GetFirst()
    {
        var produto = await _context.Produtos.FirstAsync();
        if (produto == null)
        {
            return NotFound();
        }
        return Ok(produto);
    }
    */
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetAll()
    {
        var listaProdutos = await _repository.GetAllAsync<Produto>();
        return Ok(listaProdutos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Produto>> GetById([FromRoute, Required] int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid product ID.");
        }
        var produto = await _repository.GetByIdAsync<Produto>(id);
        if (produto == null)
        {
            return NotFound($"Product with ID {id} not found.");
        }
        return Ok(produto);
    }

    [HttpPost]
    public ActionResult Create([FromBody] Produto produto)
    {
        if (produto == null)
        {
            return BadRequest("Product data is required.");
        }
        _repository.Create<Produto>(produto);
        _repository.SaveChangesAsync();
        return Created("", produto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Produto>> Update([FromRoute, Required] int id, [FromBody] Produto produto)
    {
        if (id != produto.ProdutoId)
        {
            return BadRequest("Product ID mismatch.");
        }

        await _repository.Update<Produto>(produto);
        await _repository.SaveChangesAsync();
        return Ok(produto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute, Required] int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid product ID.");
        }
        var produto = _repository.DeleteAsync<Produto>(id).Result;
        if (!produto)
        {
            return NotFound($"Product with ID {id} not found.");
        }

        await _repository.SaveChangesAsync();
        return Ok($"Product with ID {id} deleted successfully.");
    }
}
