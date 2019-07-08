using CursosResource.Domain.Entities;
using System.Threading.Tasks;

namespace CursosResource.Domain.Interfaces.Repositories
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {
        int IncluirAluno(Aluno aluno);
        Task<int> IncluirAlunoAsync(Aluno aluno);
    }
}
