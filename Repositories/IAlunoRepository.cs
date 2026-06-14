using MinhaPrimeiraApi.Models;

namespace MinhaPrimeiraApi.Repositories;

public interface IAlunoRepository
{
    List<Aluno> Listar();

    Aluno? BuscarPorId(int id);

    Aluno Criar(Aluno aluno);

    Aluno? Atualizar(int id, Aluno aluno);

    bool Deletar(int id);
}