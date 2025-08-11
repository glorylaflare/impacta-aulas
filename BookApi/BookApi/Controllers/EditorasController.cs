using AutoMapper;
using BookApi.Dtos.Editora;
using BookApi.Models;
using BookApi.Repositories;
using BookApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EditorasController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EditorasController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EditoraReadDto>>> GetAll()
    {
        var editoras = await _unitOfWork.Editoras.GetAllEditorasWithLivros();
        var editorasDto = _mapper.Map<IEnumerable<EditoraReadDto>>(editoras);
        return Ok(editorasDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EditoraReadDto>> GetById([FromRoute, Required] int id)
    {
        var editora = await _unitOfWork.Editoras.GetEditoraWithLivro(id);
        if (editora == null) return NotFound("Não foi encontrada nenhuma editora com esse id.");

        var editoraDto = _mapper.Map<EditoraReadDto>(editora);
        return Ok(editoraDto);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] EditoraCreateDto editoraDto)
    {
        var editora = _mapper.Map<EditoraModel>(editoraDto);

        await _unitOfWork.Editoras.Create(editora);
        await _unitOfWork.SaveChangesAsync();

        var dto = _mapper.Map<EditoraCreateDto>(editora); 
        return Created("A editora foi criada com sucesso!", dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update([FromRoute, Required] int id, [FromBody] EditoraUpdateDto editoraDto)
    {
        var editora = await _unitOfWork.Editoras.GetByIdAsync(id);
        if (editora == null) return NotFound("A editora não foi encontrada!");

        _mapper.Map(editoraDto, editora);
        await _unitOfWork.SaveChangesAsync();
        return Ok("A editora foi atualizada com sucesso.");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute, Required] int id)
    {
        var editora = _unitOfWork.Editoras.DeleteAsync(id).Result;
        if (!editora) return NotFound("Não foi encontrado nenhuma editora.");
        await _unitOfWork.SaveChangesAsync();
        return NoContent();
    }
}
