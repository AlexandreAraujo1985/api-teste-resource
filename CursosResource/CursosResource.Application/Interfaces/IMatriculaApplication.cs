using CursosResource.Domain.Entities;
using System.Threading.Tasks;

namespace CursosResource.Application.Interfaces
{
    public interface IMatriculaApplication : IApplicationService<Matricula>
    {
        Matricula ListarAlunosMatriculadosPorCurso(string curso);
        string InscrisaoAlunoCurso(Matricula matricula, string descricaoCurso);
        Task<string> InscrisaoAlunoCursoAsync(Matricula matricula, string descricaoCurso);
    }
}
