using MinhaPrimeiraApi.Data;
using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private readonly AppDbContext _context;

    public AlunoRepository(AppDbContext context)
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

    public Aluno? Atualizar(int id, Aluno aluno)
    {
        var alunoExistente = _context.Alunos.FirstOrDefault(a => a.Id == id);

        if (alunoExistente is null)
            return null;

        alunoExistente.Nome = aluno.Nome;

        _context.SaveChanges();

        return alunoExistente;
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
}