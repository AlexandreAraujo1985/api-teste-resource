using CursosResource.Domain.Entities;
using System.Threading.Tasks;

namespace CursosResource.Application.Interfaces
{
    public interface IAlunoApplication : IApplicationService<Aluno>
    {
        int IncluirAluno(Aluno aluno);
        Task<int> IncluirAlunoAsync(Aluno aluno);
    }
}
