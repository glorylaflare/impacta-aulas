using ApiCatalogo.Data;
using ApiCatalogo.Model;
using ApiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogo.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaRepository _repository;

    public CategoriasController(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetAll()
    {
        var listaCategorias = await _repository.GetAllAsync<Categoria>();
        return Ok(listaCategorias);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Categoria>> GetById([FromRoute, Required] int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid category ID.");
        }
        var categoria = await _repository.GetCategoriaWithProdutos(id);
        if (categoria == null)
        {
            return NotFound($"Category with ID {id} not found.");
        }
        return Ok(categoria);
    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> Create([FromBody] Categoria categoria)
    {
        if (categoria == null) {
            return BadRequest("Category data is required.");
        }
        await _repository.Create<Categoria>(categoria);
        await _repository.SaveChangesAsync();
        return Created("", categoria);
    }

    [HttpPut("{id:int}")]
    public ActionResult Update([FromRoute, Required] int id, [FromBody] Categoria categoria)
    {
        if (id != categoria.CategoriaId)
        {
            return BadRequest("Category ID mismatch.");
        }

        _repository.Update<Categoria>(categoria);
        _repository.SaveChangesAsync();
        return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute, Required] int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid category ID.");
        }
        var categoria = _repository.DeleteAsync<Categoria>(id).Result; ;
        if (!categoria)
        {
            return NotFound($"Category with ID {id} not found.");
        }
        await _repository.SaveChangesAsync();
        return Ok($"Category with ID {id} deleted successfully.");
    }
}