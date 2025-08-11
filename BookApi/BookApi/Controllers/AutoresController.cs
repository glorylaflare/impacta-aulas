using AutoMapper;
using BookApi.Dtos.Autor;
using BookApi.Models;
using BookApi.Repositories;
using BookApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AutoresController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AutoresController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AutorReadDto>>> GetAll()
    {
        var autores = await _unitOfWork.Autores.GetAllAutoresWithLivros();
        var autoresDto = _mapper.Map<IEnumerable<AutorReadDto>>(autores);
        return Ok(autoresDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AutorReadDto>> GetById([FromRoute, Required] int id)
    {
        var autor = await _unitOfWork.Autores.GetAutorWithLivro(id);
        if (autor == null) return NotFound("Não foi encontrado nenhum autor com esse id.");

        var autorDto = _mapper.Map<AutorReadDto>(autor);
        return Ok(autorDto);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] AutorCreateDto autorDto)
    {
        var autor = _mapper.Map<AutorModel>(autorDto);
        await _unitOfWork.Autores.Create(autor);
        await _unitOfWork.SaveChangesAsync();
        var dto = _mapper.Map<AutorCreateDto>(autor);
        return Created("O autor foi criado com sucesso!", dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update([FromRoute, Required] int id, [FromBody] AutorUpdateDto autorDto)
    {
        var autor = await _unitOfWork.Autores.GetByIdAsync(id);
        if (autor == null) return NotFound("O autor não foi encontrado!");

        _mapper.Map(autorDto, autor);
        await _unitOfWork.SaveChangesAsync();
        return Ok("O autor foi atualizado com sucesso.");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute, Required] int id)
    {
        var autor = _unitOfWork.Autores.DeleteAsync(id).Result;
        if (!autor) return NotFound("Não foi encontrado nenhum autor.");
        await _unitOfWork.SaveChangesAsync();
        return NoContent();
    }
}
