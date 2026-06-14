using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Services;

public class AlunoService
{
    private readonly List<Aluno> alunos = new()
    {
        new Aluno(1, "Josely"),
        new Aluno(2, "Laura"),
        new Aluno(3, "Luana")
    };

    public List<Aluno> Listar()
    {
        return alunos;
    }

    public Aluno? BuscarPorId(int id)
{
    return alunos.FirstOrDefault(aluno => aluno.Id == id);
}

    public Aluno Criar(Aluno aluno)
    {
        alunos.Add(aluno);
        return aluno;
    }
}