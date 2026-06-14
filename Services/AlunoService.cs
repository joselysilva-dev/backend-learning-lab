using MinhaPrimeiraApi.Models;
using MinhaPrimeiraApi.Repositories;

namespace MinhaPrimeiraApi.Services;

public class AlunoService
{
    private readonly IAlunoRepository _repository;

    public AlunoService(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public List<Aluno> Listar()
    {
        return _repository.Listar();
    }

    public Aluno? BuscarPorId(int id)
    {
        return _repository.BuscarPorId(id);
    }

    public Aluno Criar(Aluno aluno)
    {
        return _repository.Criar(aluno);
    }

    public Aluno? Atualizar(int id, Aluno alunoAtualizado)
    {
        return _repository.Atualizar(id, alunoAtualizado);
    }

    public bool Deletar(int id)
    {
        return _repository.Deletar(id);
    }
}