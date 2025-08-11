using AutoMapper;
using BookApi.Dtos.Genero;
using BookApi.Models;
using BookApi.Repositories;
using BookApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GenerosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenerosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GeneroReadDto>>> GetAll()
    {
        var generos = await _unitOfWork.Generos.GetAllGenerosWithLivros();
        var generosDto = _mapper.Map<IEnumerable<GeneroReadDto>>(generos);
        return Ok(generosDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GeneroReadDto>> GetById([FromRoute, Required] int id)
    {
        var genero = await _unitOfWork.Generos.GetGeneroWithLivro(id);
        if (genero == null) return NotFound("Não foi encontrado nenhum genero com esse id.");

        var generoDto = _mapper.Map<GeneroReadDto>(genero);
        return Ok(generoDto);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] GeneroCreateDto generoDto)
    {
        var genero = _mapper.Map<GeneroModel>(generoDto);

        await _unitOfWork.Generos.Create(genero);
        await _unitOfWork.SaveChangesAsync();

        var dto = _mapper.Map<GeneroCreateDto>(genero);
        return Created("Um novo genero foi adicionado ao banco de dados.", dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update([FromRoute, Required] int id, [FromBody] GeneroUpdateDto generoDto)
    {
        var genero = await _unitOfWork.Generos.GetByIdAsync(id);
        if (genero == null) return NotFound("O genero não foi encontrado.");

        _mapper.Map(generoDto, genero);

        await _unitOfWork.SaveChangesAsync();
        return Ok("O genero foi atualizado com sucesso.");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute, Required] int id)
    {
        var genero = _unitOfWork.Generos.DeleteAsync(id).Result;
        if (!genero) return NotFound("Nenhum foi encontrado nenhum genero!");
        await _unitOfWork.SaveChangesAsync();
        return NoContent();
    }
}
