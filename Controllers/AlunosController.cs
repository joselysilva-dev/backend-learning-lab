using Microsoft.AspNetCore.Mvc;
using MiniValidation;
using MinhaPrimeiraApi.DTOs;
using MinhaPrimeiraApi.Models;
using MinhaPrimeiraApi.Services;

namespace MinhaPrimeiraApi.Controllers;

[ApiController]
[Route("alunos")]
public class AlunosController : ControllerBase
{
    private readonly AlunoService _service;

    public AlunosController(AlunoService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        return Ok(_service.Listar());
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var aluno = _service.BuscarPorId(id);

        if (aluno is null)
            return NotFound("Aluno não encontrado");

        return Ok(aluno);
    }

    [HttpPost]
    public IActionResult Criar(AlunoCreateDto dto)
    {
        if (!MiniValidator.TryValidate(dto, out var errors))
            return BadRequest(errors);

        var aluno = new Aluno
        {
            Nome = dto.Nome
        };

        var novoAluno = _service.Criar(aluno);

        return Created($"/alunos/{novoAluno.Id}", novoAluno);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, AlunoUpdateDto dto)
    {
        if (!MiniValidator.TryValidate(dto, out var errors))
            return BadRequest(errors);

        var aluno = new Aluno
        {
            Nome = dto.Nome
        };

        var alunoAtualizado = _service.Atualizar(id, aluno);

        if (alunoAtualizado is null)
            return NotFound("Aluno não encontrado");

        return Ok(alunoAtualizado);
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        var deletado = _service.Deletar(id);

        if (!deletado)
            return NotFound("Aluno não encontrado");

        return NoContent();
    }
}