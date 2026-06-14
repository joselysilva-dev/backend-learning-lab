using MinhaPrimeiraApi.Models;
using MinhaPrimeiraApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<AlunoService>();

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

app.Run();