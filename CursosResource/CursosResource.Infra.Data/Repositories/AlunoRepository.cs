using CursosResource.Domain.Entities;
using CursosResource.Domain.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace CursosResource.Infra.Data.Repositories
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public int IncluirAluno(Aluno aluno)
        {
            db.Alunos.Add(aluno);
            db.SaveChanges();
            return aluno.AlunoId;
        }

        public async Task<int> IncluirAlunoAsync(Aluno aluno)
        {
            db.Alunos.Add(aluno);
            await db.SaveChangesAsync();
            return aluno.AlunoId;
        }
    }
}
