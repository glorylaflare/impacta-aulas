using ApiCatalogo.Data;
using ApiCatalogo.Model;
using ApiCatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogo.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TransacoesController : ControllerBase
{
    private readonly IRepository _repository;
    private readonly CatalogoContext _context;

    public TransacoesController(IRepository repository, CatalogoContext context)
    {
        _repository = repository;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transacao>>> GetAll()
    {
        var listaTransacoes = await _repository.GetAllAsync<Transacao>();
        return Ok(listaTransacoes);
    }
    /*
    [HttpPost]
    public ActionResult Create([FromBody] Transacao transacao)
    {
        if (transacao == null) return NotFound();

        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == transacao.ProdutoId);

        if (produto == null)
        {
            return NotFound($"Produto com ID {transacao.ProdutoId} não encontrado.");
        }

        if (produto.Estoque < transacao.Quantidade)
        {
            return BadRequest("Estoque insuficiente para realizar a transação.");
        }

        produto.Estoque -= transacao.Quantidade;
        _repository.Create<Transacao>(transacao);
        _repository.SaveChangesAsync();
        return Created("", transacao);

    }
    */
    
    [HttpDelete("{id:int}")]
    public ActionResult Delete([FromRoute, Required] int id)
    {
        var transacao = _repository.DeleteAsync<Transacao>(id);
        if (transacao == null) return NotFound();

        _repository.SaveChangesAsync();
        return Ok($"Transaction with ID {id} deleted successfully.");
    }
}
