using AutoMapper;
using BookApi.Data;
using BookApi.Dtos.Livro;
using BookApi.Models;
using BookApi.Repositories;
using BookApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LivrosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LivrosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LivroModel>>> GetAll()
    {
        var livros = await _unitOfWork.Livros.GetAllLivrosWithNames();
        var livrosDto = _mapper.Map<IEnumerable<LivroReadDto>>(livros);
        return Ok(livrosDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LivroModel>> GetById([FromRoute, Required] int id)
    {
        var livro = await _unitOfWork.Livros.GetLivroById(id);
        if (livro == null) return NotFound("Não foi encontrado nenhum livro com esse id.");

        var livroDto = _mapper.Map<LivroReadDto>(livro);
        return Ok(livroDto);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] LivroCreateDto livroDto)
    {
        var livro = _mapper.Map<LivroModel>(livroDto);

        await _unitOfWork.Livros.Create(livro);
        await _unitOfWork.SaveChangesAsync();
        
        var dto = _mapper.Map<LivroCreateDto>(livro);
        return Created("O livro foi criado com sucesso!",  dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update([FromRoute, Required] int id, [FromBody] LivroUpdateDto livroDto)
    {
        var livro = await _unitOfWork.Livros.GetByIdAsync(id);
        if (livro == null) return NotFound("O livro não foi encontrado!");
    
        _mapper.Map(livroDto, livro); // O mapper já faz a função de update
    
        await _unitOfWork.SaveChangesAsync();
        return Ok("O livro foi atualizado com sucesso.");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute, Required] int id)
    {
        var livro = _unitOfWork.Livros.DeleteAsync(id).Result;
        if (!livro) return NotFound("Não foi encontrado nenhum livro!");
        await _unitOfWork.SaveChangesAsync();
        return NoContent();
    }
}
