using CursosResource.Application.Interfaces;
using CursosResource.Domain.Entities;
using CursosResource.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace CursosResource.Application.Services
{
    public class MatriculaApplicationService : ApplicationService<Matricula>, IMatriculaApplication
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaApplicationService(IMatriculaService matriculaService) : base(matriculaService)
        {
            _matriculaService = matriculaService;
        }


        public Matricula ListarAlunosMatriculadosPorCurso(string curso)
        {
            return _matriculaService.ListarAlunosMatriculadosPorCurso(curso);
        }

        public string InscrisaoAlunoCurso(Matricula matricula, string descricaoCurso)
        {
            return _matriculaService.InscrisaoAlunoCurso(matricula, descricaoCurso);
        }

        public async Task<string> InscrisaoAlunoCursoAsync(Matricula matricula, string descricaoCurso)
        {
            return await _matriculaService.InscrisaoAlunoCursoAsync(matricula, descricaoCurso);
        }
    }
}
