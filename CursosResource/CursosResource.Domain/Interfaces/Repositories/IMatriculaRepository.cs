using CursosResource.Domain.Entities;
using System.Threading.Tasks;

namespace CursosResource.Domain.Interfaces.Repositories
{
    public interface IMatriculaRepository : IRepositoryBase<Matricula>
    {
        Matricula ListarAlunosMatriculadosPorCurso(string curso);
        string InscrisaoAlunoCurso(Matricula matricula, string descricaoCurso);
        Task<string> InscrisaoAlunoCursoAsync(Matricula matricula, string descricaoCurso);
    }
}
