using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraApi.Data;
using MinhaPrimeiraApi.Models;
using MinhaPrimeiraApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AlunoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/alunos", (AlunoService service) =>
{
    return service.Listar();
})
.WithName("GetAlunos")
.WithOpenApi();

app.MapGet("/alunos/{id}", (int id, AlunoService service) =>
{
    var aluno = service.BuscarPorId(id);

    if (aluno is null)
        return Results.NotFound("Aluno não encontrado");

    return Results.Ok(aluno);
})
.WithName("GetAlunoPorId")
.WithOpenApi();

app.MapPost("/alunos", (Aluno aluno, AlunoService service) =>
{
    var novoAluno = service.Criar(aluno);

    return Results.Created($"/alunos/{novoAluno.Id}", novoAluno);
})
.WithName("CriarAluno")
.WithOpenApi();

app.MapPut("/alunos/{id}", (int id, Aluno aluno, AlunoService service) =>
{
    var alunoAtualizado = service.Atualizar(id, aluno);

    if (alunoAtualizado is null)
        return Results.NotFound("Aluno não encontrado");

    return Results.Ok(alunoAtualizado);
})
    .WithName("AtualizarAluno")
    .WithOpenApi();
   app.MapDelete("/alunos/{id}", (int id, AlunoService service) =>
{
    var deletado = service.Deletar(id);

    if (!deletado)
        return Results.NotFound("Aluno não encontrado");

    return Results.NoContent();
})
.WithName("DeletarAluno")
.WithOpenApi();

app.Run();