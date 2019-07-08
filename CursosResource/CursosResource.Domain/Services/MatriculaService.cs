using CursosResource.Domain.Entities;
using CursosResource.Domain.Interfaces.Repositories;
using CursosResource.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace CursosResource.Domain.Services
{
    public class MatriculaService : ServiceBase<Matricula>, IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaService(IMatriculaRepository matriculaRepository) : base(matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public Matricula ListarAlunosMatriculadosPorCurso(string curso)
        {
            return _matriculaRepository.ListarAlunosMatriculadosPorCurso(curso);
        }

        public string InscrisaoAlunoCurso(Matricula matricula, string descricaoCurso)
        {
            return _matriculaRepository.InscrisaoAlunoCurso(matricula, descricaoCurso);
        }

        public async Task<string> InscrisaoAlunoCursoAsync(Matricula matricula, string descricaoCurso)
        {
            return await _matriculaRepository.InscrisaoAlunoCursoAsync(matricula, descricaoCurso);
        }
    }
}
