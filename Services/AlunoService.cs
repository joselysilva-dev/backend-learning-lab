using MinhaPrimeiraApi.Data;
using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Services;

public class AlunoService
{
    private readonly AppDbContext _context;

    public AlunoService(AppDbContext context)
    {
        _context = context;
    }

    public List<Aluno> Listar()
    {
        return _context.Alunos.ToList();
    }

    public Aluno? BuscarPorId(int id)
    {
        return _context.Alunos.FirstOrDefault(a => a.Id == id);
    }

    public Aluno Criar(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        _context.SaveChanges();

        return aluno;
    }

    public Aluno? Atualizar(int id, Aluno alunoAtualizado)
    {
        var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

        if (aluno is null)
            return null;

        aluno.Nome = alunoAtualizado.Nome;

        _context.SaveChanges();

        return aluno;
    }
    public bool Deletar(int id)
{
    var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

    if (aluno is null)
        return false;

    _context.Alunos.Remove(aluno);
    _context.SaveChanges();

    return true;
}
public bool deletar(int id)
{
    var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

    if (aluno is null)
        return false;

    _context.Alunos.Remove(aluno);
    _context.SaveChanges();

    return true;
}
}