using CursosResource.Domain.Entities;
using System.Threading.Tasks;

namespace CursosResource.Domain.Interfaces.Services
{
    public interface IMatriculaService : IServiceBase<Matricula>
    {
        Matricula ListarAlunosMatriculadosPorCurso(string curso);
        string InscrisaoAlunoCurso(Matricula matricula, string descricaoCurso);
        Task<string> InscrisaoAlunoCursoAsync(Matricula matricula, string descricaoCurso);
    }
}
