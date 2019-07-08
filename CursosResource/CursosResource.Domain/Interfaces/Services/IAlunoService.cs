using CursosResource.Domain.Entities;
using System.Threading.Tasks;

namespace CursosResource.Domain.Interfaces.Services
{
    public interface IAlunoService : IServiceBase<Aluno>
    {
        int IncluirAluno(Aluno aluno);
        Task<int> IncluirAlunoAsync(Aluno aluno);
    }
}
