using CursosResource.Domain.Entities;
using CursosResource.Domain.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace CursosResource.Infra.Data.Repositories
{
    public class MatriculaRepository : RepositoryBase<Matricula>, IMatriculaRepository
    {
        public Matricula ListarAlunosMatriculadosPorCurso(string curso)
        {
            var cursoId = db.Cursos.Where(c => c.Descricao == curso).Select(c => c.CursoId).FirstOrDefault();
            var a = db.Matriculas.Where(m => m.CursoId == cursoId);

            return a.FirstOrDefault();

            //var b = db.Matriculas.Where(m => m.CursoId == cursoId).Select(m => m.Alunos.ForEach();
        }

        public string InscrisaoAlunoCurso(Matricula matricula, string descricaoCurso)
        {
            var cursoId = db.Cursos.Where(c => c.Descricao == descricaoCurso).Select(c => c.CursoId).FirstOrDefault();
            var limiteCurso = db.Cursos.Where(c => c.CursoId == cursoId).Select(c => c.LimiteInscritos).FirstOrDefault();
            var totalInscritos = db.Matriculas.Where(m => m.CursoId == cursoId).Count();

            if (totalInscritos >= limiteCurso)
                return $"Limite de Matrículas Execidos para o Curso {descricaoCurso}";
            else
            {
                if (cursoId != 0)
                {
                    db.Matriculas.Add(new Matricula { AlunoId = matricula.AlunoId, CursoId = cursoId });
                    db.SaveChanges();
                    return "Matrícula realizada com sucesso";
                }
                else
                    return $"Curso {descricaoCurso} não encontrado";
            }
        }

        public async Task<string> InscrisaoAlunoCursoAsync(Matricula matricula, string descricaoCurso)
        {
            var cursoId = db.Cursos.Where(c => c.Descricao == descricaoCurso).Select(c => c.CursoId).FirstOrDefault();
            var limiteCurso = db.Cursos.Where(c => c.CursoId == cursoId).Select(c => c.LimiteInscritos).FirstOrDefault();
            var totalInscritos = db.Matriculas.Where(m => m.CursoId == cursoId).Count();

            if (totalInscritos >= limiteCurso)
                return $"Limite de Matrículas Execidos para o Curso {descricaoCurso}";
            else
            {
                if (cursoId != 0)
                {
                    db.Matriculas.Add(new Matricula { AlunoId = matricula.AlunoId, CursoId = cursoId });
                    await db.SaveChangesAsync();
                    return "Matrícula realizada com sucesso";
                }
                else
                    return $"Curso {descricaoCurso} não encontrado";
            }
        }
    }
}
